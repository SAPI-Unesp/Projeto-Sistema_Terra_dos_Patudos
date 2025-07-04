using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Drive.v3;
using Google.Apis.Util.Store;
using Newtonsoft.Json;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography;
using System.Text;
using System.Net;
using System.Diagnostics;
using System.IO.Compression;
using System.Web;
using Newtonsoft.Json.Linq;

namespace CadastroBanco
{
    public partial class Backup : Form
    {
        private const string ScriptUrl = "https://script.google.com/macros/s/AKfycbyN3mf66S_8EvndlvElFJwsVQANzkixVyVbcuPR17_mS2AjYHehJ_psC1Q7q05PvB7PeQ/exec";
        private readonly string[] backupFiles = { "dados.txt", "cliente.txt", "Vendas.txt" };
        private readonly string localPath = Path.Combine(Application.StartupPath);

        public Backup()
        {
            InitializeComponent();
            // CheckInternetConnection();
        }

        private void Backup_Load(object sender, EventArgs e)
        {

        }

        private const string ClientId = "136866980118-f9pplami85fafki8l58qg2jkquv1h960.apps.googleusercontent.com";
        private const string ClientSecret = "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";
        private static readonly string[] Scopes = {
            DriveService.Scope.DriveFile,
            "https://www.googleapis.com/auth/script.external_request",
            "https://www.googleapis.com/auth/drive"
        };

        private static async Task<UserCredential> AuthenticateAsync()
        {
            try
            {
                // Limpa tokens antigos
                new FileDataStore("Drive.Auth.Store", true).ClearAsync().Wait();

                return await GoogleWebAuthorizationBroker.AuthorizeAsync(
                    new ClientSecrets
                    {
                        ClientId = ClientId,
                        ClientSecret = ClientSecret
                    },
                    new[] {
                DriveService.Scope.DriveFile,
                "https://www.googleapis.com/auth/script.external_request",
                "https://www.googleapis.com/auth/drive"
                    },
                    "user",
                    CancellationToken.None,
                    new FileDataStore("Drive.Auth.Store", true));
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro de autenticação: {ex.Message}");
                return null;
            }
        }


        private async Task<string> CallAppsScriptApi(string action, Dictionary<string, string> data = null)
        {
            int maxRetries = 3;
            int retryDelay = 2000;

            for (int attempt = 1; attempt <= maxRetries; attempt++)
            {
                try
                {
                    using (var client = new HttpClient())
                    {
                        client.Timeout = TimeSpan.FromSeconds(30);
                        ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

                        var requestBody = new
                        {
                            action = action,
                            contents = data != null ? JsonConvert.SerializeObject(data) : null
                        };

                        var jsonContent = JsonConvert.SerializeObject(requestBody);
                        File.AppendAllText("api_request.log",
                            $"[{DateTime.Now}] Tentativa {attempt} - Enviando: {jsonContent.Substring(0, Math.Min(100, jsonContent.Length))}...\n");

                        var httpContent = new StringContent(jsonContent, Encoding.UTF8, "application/json");

                        var response = await client.PostAsync(ScriptUrl, httpContent);

                        if (!response.IsSuccessStatusCode)
                        {
                            var errorContent = await response.Content.ReadAsStringAsync();
                            File.AppendAllText("api_error.log",
                                $"[{DateTime.Now}] Erro HTTP {response.StatusCode}: {errorContent}\n");
                            throw new Exception($"Erro HTTP {response.StatusCode}: {errorContent}");
                        }

                        var responseContent = await response.Content.ReadAsStringAsync();
                        File.AppendAllText("api_response.log",
                            $"[{DateTime.Now}] Resposta: {responseContent.Substring(0, Math.Min(200, responseContent.Length))}...\n");

                        return responseContent;
                    }
                }
                catch (TaskCanceledException) when (attempt < maxRetries)
                {
                    File.AppendAllText("api_retry.log",
                        $"[{DateTime.Now}] Tentativa {attempt} falhou: Timeout\n");
                    await Task.Delay(retryDelay * attempt);
                }
                catch (Exception ex) when (attempt < maxRetries)
                {
                    File.AppendAllText("api_retry.log",
                        $"[{DateTime.Now}] Tentativa {attempt} falhou: {ex.Message}\n");
                    await Task.Delay(retryDelay * attempt);
                }
                catch (Exception ex)
                {
                    File.AppendAllText("api_errors.log",
                        $"[{DateTime.Now}] Erro final: {ex}\n");
                    throw;
                }
            }

            throw new Exception("Falha após várias tentativas");
        }

        private string CompressData(string data)
        {
            try
            {
                byte[] buffer = Encoding.UTF8.GetBytes(data);
                using (var memoryStream = new MemoryStream())
                {
                    using (var gzipStream = new GZipStream(memoryStream, CompressionLevel.Optimal, true))
                    {
                        gzipStream.Write(buffer, 0, buffer.Length);
                    }
                    memoryStream.Position = 0;
                    var compressedData = memoryStream.ToArray();
                    return Convert.ToBase64String(compressedData);
                }
            }
            catch (Exception ex)
            {
                File.AppendAllText("compression_error.log", $"[{DateTime.Now}] Erro ao compactar: {ex}\n");
                throw;
            }
        }

        private string DecompressData(string compressedData)
        {
            try
            {
                // Verifica se é um dado Base64 válido
                if (string.IsNullOrWhiteSpace(compressedData) ||
                    !compressedData.Trim().All(c => char.IsLetterOrDigit(c) || c == '+' || c == '/' || c == '='))
                {
                    throw new Exception("Dados não estão em formato Base64 válido");
                }

                byte[] dataBytes = Convert.FromBase64String(compressedData.Trim());

                // Verifica se é um arquivo GZIP (começa com 0x1F 0x8B)
                if (dataBytes.Length > 2 && dataBytes[0] == 0x1F && dataBytes[1] == 0x8B)
                {
                    // Descompressão GZIP
                    using (var memoryStream = new MemoryStream(dataBytes))
                    using (var gzipStream = new GZipStream(memoryStream, CompressionMode.Decompress))
                    using (var reader = new StreamReader(gzipStream))
                    {
                        return reader.ReadToEnd();
                    }
                }
                else
                {
  
                    return Encoding.UTF8.GetString(dataBytes);
                }
            }
            catch (Exception ex)
            {
                File.AppendAllText("decompress_error.log",
                    $"[{DateTime.Now}] Erro ao processar dados. Início: {compressedData.Substring(0, Math.Min(50, compressedData.Length))}\n{ex}\n");

                throw new Exception("Falha ao processar os dados recebidos. Formato pode estar incorreto.", ex);
            }
        }

        private async void exportar_Click(object sender, EventArgs e)
        {
            try
            {
                btnExport.Enabled = false;
                lblStatus.Text = "Preparando backup...";
                progressBar1.Value = 0;

                long totalSize = 0;
                var existingFiles = backupFiles.Where(f =>
                {
                    var filePath = Path.Combine(localPath, f);
                    if (File.Exists(filePath))
                    {
                        var fileInfo = new FileInfo(filePath);
                        totalSize += fileInfo.Length;
                        return true;
                    }
                    return false;
                }).ToArray();

                progressBar1.Maximum = existingFiles.Length;

                if (existingFiles.Length == 0)
                {
                    MessageBox.Show("Nenhum arquivo encontrado para backup", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (totalSize > 45 * 1024 * 1024) // 45MB
                {
                    MessageBox.Show("Tamanho total dos arquivos excede o limite de 45MB", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }


                var filesData = new Dictionary<string, string>();
                foreach (var file in existingFiles)
                {
                    try
                    {
                        var filePath = Path.Combine(localPath, file);
                        filesData[file] = File.ReadAllText(filePath);
                        progressBar1.Value++;
                        lblStatus.Text = $"Preparando {file}...";

                        await Task.Delay(100);
                    }
                    catch (IOException ioEx)
                    {
                        throw new Exception($"Erro ao ler o arquivo {file}: {ioEx.Message}");
                    }
                }

                lblStatus.Text = "Enviando para a nuvem...";
                var response = await CallAppsScriptApi("upload", new Dictionary<string, string>
        {
            { "contents", JsonConvert.SerializeObject(filesData) }
        });

                if (string.IsNullOrEmpty(response))
                {
                    throw new Exception("Nenhuma resposta recebida da API");
                }

                var result = JsonConvert.DeserializeObject<dynamic>(response);
                if (result == null)
                {
                    throw new Exception("Resposta inválida da API (null)");
                }

                if (result.success == null)
                {
                    string errorDetails = result.error?.ToString() ?? "Nenhum detalhe disponível";
                    string stackTrace = result.stack?.ToString() ?? "Nenhum stack trace disponível";
                    throw new Exception($"Resposta inválida da API. Detalhes: {errorDetails}\nStack: {stackTrace}");
                }

                if (!(bool)result.success)
                {
                    throw new Exception(result.message?.ToString() ??
                                      result.error?.ToString() ??
                                      "Erro desconhecido durante o backup");
                }

                MessageBox.Show("Backup concluído com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {

                MessageBox.Show($"Erro durante o backup:\n{ex.Message}\n\nDetalhes técnicos:\n{ex.ToString()}",
                              "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);


                Console.WriteLine($"Erro no backup: {ex.ToString()}");
                File.AppendAllText("backup_errors.log", $"[{DateTime.Now}] {ex.ToString()}\n");
            }
            finally
            {
                btnExport.Enabled = true;
                lblStatus.Text = "Pronto";
                progressBar1.Value = 0;
            }
        }

        private async void btnImport_Click_1(object sender, EventArgs e)
        {
            try
            {
                btnImport.Enabled = false;
                progressBar1.Value = 0;
                lblStatus.Text = "Preparando restauração...";

                File.AppendAllText("backup_operations.log",
                    $"\n[{DateTime.Now}] INICIANDO RESTAURAÇÃO =====================\n");


                lblStatus.Text = "Conectando ao Google Drive...";
                string response;

                try
                {
                    response = await CallAppsScriptApi("download");
                    File.AppendAllText("backup_operations.log",
                        $"[{DateTime.Now}] Resposta recebida (início): {response?.Substring(0, Math.Min(200, response?.Length ?? 0))}...\n");
                }
                catch (Exception ex)
                {
                    File.AppendAllText("backup_errors.log",
                        $"[{DateTime.Now}] ERRO DE CONEXÃO: {ex}\n");
                    throw new Exception("Falha na comunicação com o Google Drive", ex);
                }

                // Processamento da resposta
                dynamic result = JsonConvert.DeserializeObject<dynamic>(response);

                if (result == null || !(bool)result.success)
                {
                    throw new Exception(result?.error?.ToString() ?? "Erro desconhecido no servidor");
                }

                // Extração dos dados corrigindo a desserialização aninhada
                string jsonDesgraca;
                try
                {
                    // Primeiro nível de desserialização
                    var firstLevel = JsonConvert.DeserializeObject<Dictionary<string, string>>(result.contents.ToString());

                    // Segundo nível (dados reais)
                    jsonDesgraca = firstLevel["contents"];
                    File.AppendAllText("backup_debug.log",
                        $"[{DateTime.Now}] Dados extraídos (início): {jsonDesgraca.Substring(0, Math.Min(200, jsonDesgraca.Length))}...\n");
                }
                catch (Exception ex)
                {
                    File.AppendAllText("backup_errors.log",
                        $"[{DateTime.Now}] ERRO AO EXTRAIR CONTEÚDO: {ex}\n");
                    throw new Exception("Formato inválido dos dados do backup", ex);
                }

                // Desserialização dos arquivos
                Dictionary<string, string> filesDict;
                try
                {
                    filesDict = JsonConvert.DeserializeObject<Dictionary<string, string>>(jsonDesgraca);
                    File.AppendAllText("backup_debug.log",
                        $"[{DateTime.Now}] Backup contém {filesDict.Count} arquivos: {string.Join(", ", filesDict.Keys)}\n");
                }
                catch (Exception ex)
                {
                    File.AppendAllText("backup_errors.log",
                        $"[{DateTime.Now}] ERRO AO DESSERIALIZAR ARQUIVOS: {ex}\n");
                    throw new Exception("Falha ao interpretar os arquivos do backup", ex);
                }

                // Restauração dos arquivos
                progressBar1.Maximum = backupFiles.Length;
                int restoredCount = 0;
                int errorCount = 0;

                foreach (var fileName in backupFiles)
                {
                    try
                    {
                        lblStatus.Text = $"Restaurando {fileName}...";
                        var filePath = Path.Combine(localPath, fileName);

                        if (filesDict.TryGetValue(fileName, out var fileContent))
                        {
                            Directory.CreateDirectory(Path.GetDirectoryName(filePath));

                            // Substitui o arquivo local
                            File.WriteAllText(filePath, fileContent);
                            restoredCount++;

                            File.AppendAllText("backup_debug.log",
                                $"[{DateTime.Now}] {fileName} restaurado com sucesso\n");
                        }
                        else
                        {
                            File.AppendAllText("backup_debug.log",
                                $"[{DateTime.Now}] {fileName} não encontrado no backup\n");
                        }

                        progressBar1.Value++;
                        await Task.Delay(50); 
                    }
                    catch (Exception ex)
                    {
                        errorCount++;
                        File.AppendAllText("backup_errors.log",
                            $"[{DateTime.Now}] ERRO AO RESTAURAR {fileName}: {ex}\n");
                    }
                }

                string report = $"Restauração concluída!\n" +
                               $"• Arquivos restaurados: {restoredCount}\n" +
                               $"• Arquivos não encontrados: {backupFiles.Length - restoredCount}\n" +
                               $"• Erros durante o processo: {errorCount}";

                MessageBox.Show(report, "Resultado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                string errorDetails = $"Erro durante a restauração:\n{ex.Message}";

                if (ex.InnerException != null)
                {
                    errorDetails += $"\n\nDetalhes técnicos:\n{ex.InnerException.Message}";
                }

                MessageBox.Show(errorDetails, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                File.AppendAllText("backup_errors.log",
                    $"[{DateTime.Now}] ERRO CRÍTICO: {ex}\n");
            }
            finally
            {
                btnImport.Enabled = true;
                lblStatus.Text = "Pronto";
                progressBar1.Value = 0;

                File.AppendAllText("backup_operations.log",
                    $"[{DateTime.Now}] OPERAÇÃO FINALIZADA =====================\n");
            }
        }
    }
}
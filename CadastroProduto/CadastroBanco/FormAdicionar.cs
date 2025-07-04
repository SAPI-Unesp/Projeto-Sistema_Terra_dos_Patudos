using CadastroBanco;
using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace CadastroBanco
{
    public partial class FormAdicionar : Form
    {
        private Form2 formPrincipal; // Referência ao Form1 (formulário principal)
        string caminhoArquivo = "dados.txt"; // Mesmo arquivo usado no Form1
        string caminhoArquivoCategoria = "categoria.txt";
        public string cbtexto;
        public FormAdicionar(Form2 form)
        {
            InitializeComponent();
            this.formPrincipal = form; // Recebe a referência do Form2
            if (File.Exists(caminhoArquivoCategoria))
            {
                var linhas = File.ReadAllLines(caminhoArquivoCategoria);
                foreach (var linha in linhas)
                {
                   
                 cbCategoria.Items.Add(linha);
                    
                }
            }
            txtCaderno.Text = ObterProximoIdLivroDisponivel();
          
        }

        // Botão para confirmar e adicionar os dados ao arquivo TXT
        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            
        }

        private void FormAdicionar_Load(object sender, EventArgs e)
        {

        }

        private void btnConfirmar_Click_1(object sender, EventArgs e)
        {
            string pagLivro = ObterProximoIdLivroDisponivel();
                string categoria = cbCategoria.Text;
                cbtexto = categoria;
                string descricao = txtDesc.Text;
                decimal qnt = numQnt.Value;
                decimal preco = numPreco.Value;

            if (File.Exists(caminhoArquivoCategoria))
            {
                // Lê todas as linhas do arquivo
                var categorias = File.ReadAllLines(caminhoArquivoCategoria);

                // Verifica se a categoria está presente
                if (!categorias.Contains(categoria))
                {
                    // A categoria não está no arquivo
                    //MessageBox.Show("Categoria não encontrada.");
                    File.AppendAllText(caminhoArquivoCategoria, $"{categoria}{Environment.NewLine}");
                }
             
            }
            else
            {
                File.WriteAllText(caminhoArquivoCategoria, $"{categoria}{Environment.NewLine}");
            }
       

            if (string.IsNullOrWhiteSpace(categoria))
            {
                MessageBox.Show("Preencha a categoria.");
                return;
            }

            int proximoId = ObterProximoIdDisponivel();

            // Adiciona ao arquivo
            File.AppendAllText(caminhoArquivo, $"{proximoId}*{pagLivro}*{categoria}*{descricao}*{qnt}*{preco}*{DateTime.Now}*a vender*{Environment.NewLine}");
            MessageBox.Show("Dados adicionados com sucesso!");

            // Atualiza o DataGridView no formulário principal
            formPrincipal.ExibirDados();

            // Fecha o formulário de adição após a inserção
            this.Close();
        }
        private int ObterProximoIdDisponivel()
        {
            // Se o arquivo não existir, o primeiro ID será 1
            if (!File.Exists(caminhoArquivo))
                return 1;

            // Ler todas as linhas do arquivo
            var linhas = File.ReadAllLines(caminhoArquivo);

            // Extrair os IDs existentes (supondo que o ID está na primeira coluna)
            var idsExistentes = linhas
                .Where(l => !string.IsNullOrWhiteSpace(l)) // Ignorar linhas vazias
                .Select(l => int.Parse(l.Split('*')[0].Trim())) // Pegar o ID (primeiro campo)
                .OrderBy(id => id) // Ordenar por ID
                .ToList();

            // Encontrar o menor ID não utilizado
            int proximoId = 0; // Começa com o ID 1
            foreach (var id in idsExistentes)
            {
                if (id == proximoId)
                    proximoId++; // Se o ID atual já está em uso, incrementar
                else
                    break; // Encontrar o menor ID não usado
            }

            return proximoId;
        }

        private string ObterProximoIdLivroDisponivel()
        {
            // Se o arquivo não existir, o primeiro ID será "00A-00"
            if (!File.Exists(caminhoArquivo))
                return "00A-00";

            // Ler todas as linhas do arquivo
            var linhas = File.ReadAllLines(caminhoArquivo);

            // Extrair os IDs existentes (supondo que o ID está no segundo campo)
            var idsExistentes = linhas
                .Where(l => !string.IsNullOrWhiteSpace(l)) // Ignorar linhas vazias
                .Select(l => l.Split('*'))
                .Where(partes => partes.Length > 1) // Garantir que existem pelo menos 2 partes
                .Select(partes => partes[1].Trim()) // Pegar o segundo campo, que contém o ID
                .ToList();
            idsExistentes.Sort();

            // Encontrar o próximo ID disponível
            string proximoId = "00-00"; // Começa com o ID "00A-00"

            int parteNumn = 0;
            int parteAlfan = 0;
            foreach (var id in idsExistentes)
            {
                if(id.Contains("-"))
                {
                    var partes = id.Split('-');
                    if (partes[0] != "" && partes[1] != "")
                    {
                        try
                        {
                            string parteAlfa = partes[0]; // Ex: "13A"
                            string parteNum = partes[1];
                            parteAlfa = new string(parteAlfa.Where(char.IsDigit).ToArray());
                            parteNum = new string(parteNum.Where(char.IsDigit).ToArray());
                            // Verifica se a parte numérica é menor que 26
                            if(parteAlfan < int.Parse(parteAlfa))
                            {
                                parteAlfan = int.Parse(parteAlfa);
                                parteNumn = 0;
                            }
                                

                            if (parteNumn < int.Parse(parteNum) && parteAlfan == int.Parse(parteAlfa) )
                            {
                                parteNumn = int.Parse(parteNum);
                            }
                                
                        }
                        catch (Exception er)
                        {

                        }

                        // Monta o novo ID atualizado
                        // var novoId = $"{parteAlfan}-{parteNumn:D2}"; // Formata a parte numérica com dois dígitos



                    }
                }
                    
                
                
            }

            if (parteNumn < 30)
            {
                parteNumn++;
            }
            else
            {
                parteAlfan++;
                parteNumn = 0;
            }
            var novoId = $"{parteAlfan}-{parteNumn:D2}";
            return novoId;
        }




        private void cbCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }
    }
}

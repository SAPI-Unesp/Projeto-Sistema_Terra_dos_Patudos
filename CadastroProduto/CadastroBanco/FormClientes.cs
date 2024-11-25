using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace CadastroBanco
{
    public partial class FormClientes : Form
    {
        string caminhoArquivo = "dados.txt"; // Arquivo onde os dados serão armazenados
        string caminhoArquivoVendas = "Vendas.txt"; // Arquivo onde os dados serão armazenados
        string caminhoArquivoCategoria = "categoria.txt";
        string caminhoArquivoCarrinho = "carrinho.txt";
        string caminhoArquivoCliente = "cliente.txt";
        string itensComId = "itensComId.txt";
        public FormClientes()
        {
            InitializeComponent();

            dataGridViewDados.AllowUserToAddRows = false;
            dataGridViewDados.ReadOnly = true;
        }

        private void FormClientes_Load(object sender, EventArgs e)
        {
            ExibirTudo();
        }

        public void AddCliente()
        {
            var linhasVendas = File.ReadAllLines(caminhoArquivoVendas);

            List<string> linhasClientes = new List<string>();
            if (!File.Exists(caminhoArquivoCliente))
            {
                File.WriteAllText(caminhoArquivoCliente, "");
            }

            linhasClientes = File.ReadAllLines(caminhoArquivoCliente).ToList();

            foreach (var linhaVenda in linhasVendas)
            {
                var dadosVenda = linhaVenda.Split('*');
                if (dadosVenda.Length >= 10)
                {
                    string precoVenda = dadosVenda[5].Trim();
                    string pessoa = dadosVenda[7].Trim();
                    string telefonep = dadosVenda[8].Trim();

                    bool clienteExistente = false;

                    for (int j = 0; j < linhasClientes.Count; j++)
                    {
                        var dadosCliente = linhasClientes[j].Split('*');
                        string cliente = dadosCliente[1].Trim();
                        string telefone = dadosCliente[2].Trim();
                        string desconto = dadosCliente[4].Trim();
                        string credito = dadosCliente[5].Trim();

                        if (pessoa.Equals(cliente))
                        {
                            clienteExistente = true;
                            

                            linhasClientes[j] = $"{j}*{cliente}*{telefone}*0*0*{credito}";
                            
                            break;
                        }
                    }

                    if (!clienteExistente && pessoa != "")
                    {
                        string novaLinhaCliente = $"{linhasClientes.Count}*{pessoa}*{telefonep}*0*0*0";
                        linhasClientes.Add(novaLinhaCliente);
                    }
                }
            }

            File.WriteAllLines(caminhoArquivoCliente, linhasClientes);

            linhasClientes = File.ReadAllLines(caminhoArquivoCliente).ToList();
            var linhasCliente2 = File.ReadAllLines(caminhoArquivoCliente).ToList();

            foreach (var linha in linhasClientes)
            {
                var dadosCliente = linha.Split('*');
                string id = dadosCliente[0].Trim();
                string cliente = dadosCliente[1].Trim();
                string telefone = dadosCliente[2].Trim();
                string desconto = dadosCliente[4].Trim();
                string credito = dadosCliente[5].Trim();
                decimal valorDivida = 0;

                foreach(var linhaV in linhasVendas)
                {
                    var dadosVenda = linhaV.Split('*');

                    if(dadosVenda.Length >= 10)
                    {
                        string precoVenda = dadosVenda[5].Trim();
                        string pessoa = dadosVenda[7].Trim();

                        if (pessoa.Equals(cliente))
                        {
                            valorDivida += decimal.Parse(precoVenda);
                        }
                    }
                }
                int linhasParaAtualizar = linhasClientes.FindIndex(l => l.StartsWith(id + "*"));

                linhasCliente2[linhasParaAtualizar] = $"{id}*{cliente}*{telefone}*{valorDivida.ToString()}*0*{credito}";
            }

            File.WriteAllLines(caminhoArquivoCliente, linhasCliente2);
        }

        private void ExibirTudo()
        {
            dataGridViewDados.Rows.Clear();

            if (File.Exists(caminhoArquivoCliente))
            {
                var linhas = File.ReadAllLines(caminhoArquivoCliente);
                foreach (var linha in linhas)
                {
                    var dados = linha.Split('*');

                    // Certifique-se de que há 4 campos (categoria, descrição, quantidade, preço) // agr to pegando o id junto já q ele tá iterável
                    if (dados.Length == 6)
                    {
                        string id = dados[0].Trim();
                        string cliente = dados[1].Trim();
                        string telefone = dados[2].Trim();
                        string divida = dados[3].Trim();
                        string desconto = dados[4].Trim();
                        string credito = dados[5].Trim();

                        // Adicionar os dados no DataGridView
                        dataGridViewDados.Rows.Add(id, cliente, telefone, divida, credito);
                    }
                }
            }
            else
            {
                MessageBox.Show("Nenhum dado encontrado.");
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dataGridViewDados.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecione um cliente para editar.");
                return;
            }

            int index = dataGridViewDados.SelectedRows[0].Index;
            var linhaSelecionada = dataGridViewDados.Rows[index];

            // Extrair dados da linha selecionada, incluindo o ID
            string id = linhaSelecionada.Cells[0].Value.ToString();
            string cliente = linhaSelecionada.Cells[1].Value.ToString();
            string telefone = linhaSelecionada.Cells[2].Value.ToString();
            decimal divida = decimal.Parse(linhaSelecionada.Cells[3].Value.ToString());
            decimal credito = decimal.Parse(linhaSelecionada.Cells[4].Value.ToString());

            // Abrir o formulário de atualização com os dados atuais
            FormAtualizarCliente formAtualizarCliente = new FormAtualizarCliente(id, cliente, telefone, credito);

            if(formAtualizarCliente.ShowDialog() == DialogResult.OK)
            {
                var linhasC = File.ReadAllLines(caminhoArquivoCliente).ToList();

                int linhaParaAtualizar = linhasC.FindIndex(l => l.StartsWith(id + "*"));

                if (linhaParaAtualizar >= 0)
                {
                    // Atualizar a linha com os novos dados
                    linhasC[linhaParaAtualizar] = $"{id}*{formAtualizarCliente.Cliente}*{formAtualizarCliente.Telefone}*{divida}*0*{formAtualizarCliente.Credito}";

                    // Escrever as alterações no arquivo
                    File.WriteAllLines(caminhoArquivoCliente, linhasC);
                    MessageBox.Show("Dados do cliente atualizados com sucesso!");

                    // Recarregar os dados no DataGridView
                    ExibirTudo();
                }
                else
                {
                    MessageBox.Show("Erro ao achar os dados do cliente.");
                }

                var linhasV = File.ReadAllLines(caminhoArquivoVendas).ToList();
                var linhasV1 = File.ReadAllLines(caminhoArquivoVendas);
                var linhasV2 = File.ReadAllLines(caminhoArquivoVendas).ToList();
                try
                {

                    int count = 0;
                    foreach (var linha in linhasV1)
                    {
                        var dadosVenda = linha.Split('*');
                        if (dadosVenda.Length >= 10)
                        {
                            string idv = dadosVenda[0].Trim();
                            string idl = dadosVenda[1].Trim();
                            string categoriaVenda = dadosVenda[2].Trim();
                            string descricaoVenda = dadosVenda[3].Trim();
                            string qntVenda = dadosVenda[4].Trim();
                            string precoVenda = dadosVenda[5].Trim();
                            string dataVenda = dadosVenda[6].Trim();
                            string pessoa = dadosVenda[7].Trim();
                            string telefonev = dadosVenda[8].Trim();
                            string pendente = dadosVenda[9].Trim();

                            if (pessoa.Equals(cliente))
                            {
                                int linhasParaAtualizar = linhasV2.FindIndex(l => l.StartsWith(idv + "*"));
                                //MessageBox.Show(linhasParaAtualizar.ToString());
                                linhasV[linhasParaAtualizar] = $"{idv}*{idl}*{categoriaVenda}*{descricaoVenda}*{qntVenda}*{precoVenda}*{dataVenda}*{formAtualizarCliente.Cliente}*{formAtualizarCliente.Telefone}*{pendente}";
                                
                            }
                        }
                        count++;
                    }
                    File.WriteAllLines(caminhoArquivoVendas, linhasV);
                    MessageBox.Show("Dados da venda atualizados com sucesso!");

                }
                catch (Exception exc)
                {
                    MessageBox.Show(exc.Message);
                }
            }
            else
            {
                MessageBox.Show("Erro ao atualizar os dados do cliente.");
            }
        }

        private void dataGridViewDados_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}

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
using System.Security;
namespace CadastroBanco
{
    public partial class FormTabelaVenda : Form
    {
        string caminhoArquivoVendas = "Vendas.txt";

        public FormTabelaVenda()
        {
            InitializeComponent();
            ExibirDados();
        }

        private void dataGridViewDados_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        public void ExibirDados()
        {
            dataGridViewDados.Rows.Clear(); // Limpa as linhas antes de exibir

            if (File.Exists(caminhoArquivoVendas))
            {
                var linhas = File.ReadAllLines(caminhoArquivoVendas);
                foreach (var linha in linhas)
                {
                    var dados = linha.Split('*');

                    // Certifique-se de que há 4 campos (categoria, descrição, quantidade, preço) // agr to pegando o id junto já q ele tá iterável
                    if (dados.Length == 9)
                    {
                        string id = dados[0].Trim();
                        string categoria = dados[1].Trim();
                        string descricao = dados[2].Trim();
                        string qnt = dados[3].Trim();
                        string preco = dados[4].Trim();
                        string data = dados[5].Trim();
                        string nome = dados[6].Trim();
                        string telefone = dados[7].Trim();
                        string pagamento = dados[8].Trim();
                        // Adicionar os dados no DataGridView
                        dataGridViewDados.Rows.Add(id, categoria, descricao, qnt, preco, data, nome, telefone, pagamento);
                    }
                }
                dataGridViewDados.ClearSelection();
            }
            else
            {
                MessageBox.Show("Nenhum dado encontrado.");
            }
        }

    }
}

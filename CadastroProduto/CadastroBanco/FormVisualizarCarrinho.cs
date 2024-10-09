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
    public partial class FormVisualizarCarrinho : Form
    {

        string caminhoArquivo = "dados.txt"; // Arquivo onde os dados serão armazenados
        string caminhoArquivoVendas = "Vendas.txt"; // Arquivo onde os dados serão armazenados
        string caminhoArquivoCategoria = "categoria.txt";
        string caminhoArquivoCarrinho = "carrinho.txt";
        string itensComId = "itensComId.txt";
        public FormVisualizarCarrinho()
        {
            InitializeComponent();
        }

        private void FormVisualizarCarrinho_Load(object sender, EventArgs e)
        {
            ExibirDados();
        }

        public void ExibirDados()
        {
            dataGridViewDados.Rows.Clear(); // Limpa as linhas antes de exibir

            if (File.Exists(caminhoArquivoCarrinho))
            {
                var linhas = File.ReadAllLines(caminhoArquivoCarrinho);
                foreach (var linha in linhas)
                {
                    var dados = linha.Split('*');

                    // Certifique-se de que há 4 campos (categoria, descrição, quantidade, preço) // agr to pegando o id junto já q ele tá iterável
                    if (dados.Length == 5)
                    {
                        string id = dados[0].Trim();
                        string categoria = dados[1].Trim();
                        string descricao = dados[2].Trim();
                        string qnt = dados[3].Trim();
                        string preco = dados[4].Trim();

                        // Adicionar os dados no DataGridView
                        dataGridViewDados.Rows.Add(id, categoria, descricao, qnt, preco);
                    }
                }
            }
            else
            {
                MessageBox.Show("Nenhum dado encontrado.");
            }

        }
        private void dataGridViewDados_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}

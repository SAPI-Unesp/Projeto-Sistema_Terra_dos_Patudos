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
            dataGridViewDados.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }


        private void btnRemover_Click(object sender, EventArgs e)
        {
            if (dataGridViewDados.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecione um item para deletar.");
                return;
            }

            if (dataGridViewDados.SelectedRows.Count > 1)
            {
                MessageBox.Show("Selecione apenas um item.");
                return;
            }

            DialogResult confirmResult = MessageBox.Show("Você tem certeza que deseja deletar este item do carrinho?",
                                                         "Confirmação de Exclusão",
                                                         MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {
                // Se o usuário confirmar, excluir o item
                int index = dataGridViewDados.SelectedRows[0].Index;
                var linhaSelecionada = dataGridViewDados.Rows[index];

                string id = linhaSelecionada.Cells[0].Value.ToString(); // Pega o ID

                var linhas = File.ReadAllLines(caminhoArquivoCarrinho).ToList();

                // Encontra a linha correspondente pelo ID
                int linhaParaDeletar = linhas.FindIndex(l => l.StartsWith(id + "*"));
                if (linhaParaDeletar >= 0)
                {
                    linhas.RemoveAt(linhaParaDeletar); // Remove o item correspondente ao ID
                    File.WriteAllLines(caminhoArquivoCarrinho, linhas);
                    MessageBox.Show("Dados deletados com sucesso!");
                    ExibirDados(); // Recarregar os dados no DataGridView
                }
                else
                {
                    MessageBox.Show("Erro ao encontrar o item para deletar.");
                }
            }
            else
            {
                // Se o usuário cancelar, não fazer nada
                MessageBox.Show("Ação de exclusão cancelada.");
            }

            ExibirDados();
        }
    }
}
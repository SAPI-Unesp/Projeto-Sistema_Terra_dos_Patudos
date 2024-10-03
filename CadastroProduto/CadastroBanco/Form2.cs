using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace CadastroBanco
{
    public partial class Form2 : Form
    {
        string caminhoArquivo = "dados.txt"; // Arquivo onde os dados serão armazenados

        public Form2()
        {
            InitializeComponent();

            //dataGridViewDados.ColumnCount = 2;
            //dataGridViewDados.Columns[0].Name = "Id";
            //dataGridViewDados.Columns[1].Name = "Tipo";
            //dataGridViewDados.Columns[1].Name = "Peça";

            // Impedir edição direta no DataGridView
            dataGridViewDados.AllowUserToAddRows = false;
            dataGridViewDados.ReadOnly = true;
        }

        // Adicionar dados ao arquivo



        // Atualizar dados
        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            if (dataGridViewDados.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecione um item para atualizar.");
                return;
            }

            string nome = txtNome.Text;
            string idade = txtIdade.Text;

            if (string.IsNullOrWhiteSpace(nome) || string.IsNullOrWhiteSpace(idade))
            {
                MessageBox.Show("Preencha todos os campos.");
                return;
            }

            int index = dataGridViewDados.SelectedRows[0].Index;

            // Ler todas as linhas
            var linhas = File.ReadAllLines(caminhoArquivo).ToList();
            linhas[index] = $"{nome},{idade}"; // Atualiza o item selecionado

            // Sobrescreve o arquivo com as alterações
            File.WriteAllLines(caminhoArquivo, linhas);
            MessageBox.Show("Dados atualizados com sucesso!");
            LimparCampos();
            ExibirDados(); // Recarregar os dados atualizados no DataGridView
        }

        // Deletar dados

        private void LimparCampos()
        {
            txtNome.Clear();
            txtIdade.Clear();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void btnAdicionar_Click_1(object sender, EventArgs e)
        {
            FormAdicionar formAdicionar = new FormAdicionar(this);
            formAdicionar.ShowDialog();
        }

        public void ExibirDados()
        {
           dataGridViewDados.Rows.Clear(); // Limpa as linhas antes de exibir

            if (File.Exists(caminhoArquivo))
            {
                var linhas = File.ReadAllLines(caminhoArquivo);
                foreach (var linha in linhas)
                {
                    var dados = linha.Split(',');

                    // Certifique-se de que há 4 campos (categoria, descrição, quantidade, preço)
                    if (dados.Length == 4)
                    {
                        string categoria = dados[0].Trim();
                        string descricao = dados[1].Trim();
                        string qnt = dados[2].Trim();
                        string preco = dados[3].Trim();

                        // Adicionar os dados no DataGridView
                        dataGridViewDados.Rows.Add(0 , categoria, descricao, qnt, preco);
                    }
                }
            }
            else
            {
                MessageBox.Show("Nenhum dado encontrado.");
            }
        }

        private void btnExibir_Click_1(object sender, EventArgs e)
        {
            ExibirDados();
        }

        private void btnAtualizar_Click_1(object sender, EventArgs e)
        {
            if (dataGridViewDados.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecione um item para atualizar.");
                return;
            }

            string nome = txtNome.Text;
            string idade = txtIdade.Text;

            if (string.IsNullOrWhiteSpace(nome) || string.IsNullOrWhiteSpace(idade))
            {
                MessageBox.Show("Preencha todos os campos.");
                return;
            }

            int index = dataGridViewDados.SelectedRows[0].Index;

            // Ler todas as linhas
            var linhas = File.ReadAllLines(caminhoArquivo).ToList();
            linhas[index] = $"{nome},{idade}"; // Atualiza o item selecionado

            // Sobrescreve o arquivo com as alterações
            File.WriteAllLines(caminhoArquivo, linhas);
            MessageBox.Show("Dados atualizados com sucesso!");
            LimparCampos();
            ExibirDados(); // Recarregar os dados atualizados no DataGridView
        }

        private void btnDeletar_Click_1(object sender, EventArgs e)
        {
            if (dataGridViewDados.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecione um item para deletar.");
                return;
            }

            int index = dataGridViewDados.SelectedRows[0].Index;

            // Ler todas as linhas
            var linhas = File.ReadAllLines(caminhoArquivo).ToList();
            linhas.RemoveAt(index); // Remove o item selecionado

            // Sobrescreve o arquivo com as alterações
            File.WriteAllLines(caminhoArquivo, linhas);
            MessageBox.Show("Dados deletados com sucesso!");
            ExibirDados(); // Recarregar os dados no DataGridView
        }
    }
}

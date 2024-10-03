using System;
using System.IO;
using System.Linq;
using System.Security;
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
            ExibirDados();
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

                    // Certifique-se de que há 4 campos (categoria, descrição, quantidade, preço) // agr to pegando o id junto já q ele tá iterável
                    if (dados.Length == 5)
                    {
                        string id = dados[0].Trim();
                        string categoria = dados[1].Trim();
                        string descricao = dados[2].Trim();
                        string qnt = dados[3].Trim();
                        string preco = dados[4].Trim();

                        // Adicionar os dados no DataGridView
                        dataGridViewDados.Rows.Add(id , categoria, descricao, qnt, preco);
                    }
                }
                dataGridViewDados.ClearSelection();
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

            // Pegar o índice da linha selecionada
            int index = dataGridViewDados.SelectedRows[0].Index;
            var linhaSelecionada = dataGridViewDados.Rows[index];

            // Extrair dados da linha selecionada, incluindo o ID
            string id = linhaSelecionada.Cells[0].Value.ToString();
            string categoria = linhaSelecionada.Cells[1].Value.ToString();
            string descricao = linhaSelecionada.Cells[2].Value.ToString();
            decimal qnt = decimal.Parse(linhaSelecionada.Cells[3].Value.ToString());
            decimal preco = decimal.Parse(linhaSelecionada.Cells[4].Value.ToString());

            // Abrir o formulário de atualização com os dados atuais
            FormAtualizar formAtualizar = new FormAtualizar(categoria, descricao, qnt, preco);

            if (formAtualizar.ShowDialog() == DialogResult.OK)
            {
                // Se o usuário clicar em OK no formulário de atualização, realizar a atualização no arquivo

                // Ler todas as linhas do arquivo
                var linhas = File.ReadAllLines(caminhoArquivo).ToList();

                // Encontrar a linha correspondente pelo ID
                int linhaParaAtualizar = linhas.FindIndex(l => l.StartsWith(id + ","));

                if (linhaParaAtualizar >= 0)
                {
                    // Atualizar a linha com os novos dados
                    linhas[linhaParaAtualizar] = $"{id},{formAtualizar.Categoria},{formAtualizar.Descricao},{formAtualizar.Qnt},{formAtualizar.Preco}";

                    // Escrever as alterações no arquivo
                    File.WriteAllLines(caminhoArquivo, linhas);
                    MessageBox.Show("Dados atualizados com sucesso!");

                    // Recarregar os dados no DataGridView
                    ExibirDados();
                }
                else
                {
                    MessageBox.Show("Erro ao encontrar o item para atualizar.");
                }
            }

        }

        private void btnDeletar_Click_1(object sender, EventArgs e)
        {
            if (dataGridViewDados.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecione um item para deletar.");
                return;
            }

            DialogResult confirmResult = MessageBox.Show("Você tem certeza que deseja deletar este item?",
                                                         "Confirmação de Exclusão",
                                                         MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {
                // Se o usuário confirmar, excluir o item
                int index = dataGridViewDados.SelectedRows[0].Index;
                var linhaSelecionada = dataGridViewDados.Rows[index];

                string id = linhaSelecionada.Cells[0].Value.ToString(); // Pega o ID

                var linhas = File.ReadAllLines(caminhoArquivo).ToList();

                // Encontra a linha correspondente pelo ID
                int linhaParaDeletar = linhas.FindIndex(l => l.StartsWith(id + ","));
                if (linhaParaDeletar >= 0)
                {
                    linhas.RemoveAt(linhaParaDeletar); // Remove o item correspondente ao ID
                    File.WriteAllLines(caminhoArquivo, linhas);
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
        }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            //Desseleciona os itens selecionados da tabela
            dataGridViewDados.ClearSelection();

            //Verifica se tem algum texto na busca
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                MessageBox.Show("Nenhum item foi pesquisado.");
                return;
            }

            string Busca = textBox1.Text;

            
            dataGridViewDados.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            try
            {
                //Verifica se a classificação ou a descrição é igual ao texto buscado
                foreach (DataGridViewRow row in dataGridViewDados.Rows)
                {
                    string BuscaCat = row.Cells[1].Value.ToString();
                    string BuscaDes = row.Cells[2].Value.ToString();
                    if (BuscaCat.ToLower().Equals(Busca.ToLower()) || BuscaDes.ToLower().Equals(Busca.ToLower()))
                    {
                        //Deixa visivel as linhas que tem a classificação ou a descrição igual ao texto buscado
                        row.Visible = true;
                        row.Selected = true;
                    }
                    else
                    {
                        //Deixa invisivel as linhas que não tem a classificação ou a descrição igual ao texto buscado
                        row.Visible = false;
                    }
                }
            }

            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
            //Se não achar nada ele exibe todos os itens denovo e retorna a mensagem
            if (dataGridViewDados.SelectedRows.Count == 0)
            {
                ExibirDados();
                MessageBox.Show("Nenhum item encontrado.");
                return;
            }
            else 
            {
                dataGridViewDados.ClearSelection();
                return;
            }


        }

        private void btnVender_Click(object sender, EventArgs e)
        {
            if (dataGridViewDados.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecione um item para vender.");
                return;
            }

            // Pegar o índice da linha selecionada
            int index = dataGridViewDados.SelectedRows[0].Index;
            var linhaSelecionada = dataGridViewDados.Rows[index];

            // Extrair dados da linha selecionada, incluindo o ID
            string id = linhaSelecionada.Cells[0].Value.ToString();
            string categoria = linhaSelecionada.Cells[1].Value.ToString();
            string descricao = linhaSelecionada.Cells[2].Value.ToString();
            decimal qnt = decimal.Parse(linhaSelecionada.Cells[3].Value.ToString());
            decimal preco = decimal.Parse(linhaSelecionada.Cells[4].Value.ToString());

            FormVender formVender = new FormVender(qnt, preco);

            if(formVender.ShowDialog() == DialogResult.OK)
            {
                // Se o usuário clicar em OK no formulário de venda, realiza a atualização no arquivo

                // Ler todas as linhas do arquivo
                var linhas = File.ReadAllLines(caminhoArquivo).ToList();

                // Encontrar a linha correspondente pelo ID
                int linhaParaAtualizar = linhas.FindIndex(l => l.StartsWith(id + ","));

                if (linhaParaAtualizar >= 0)
                {
                    // Atualizar a linha com os novos dados
                    linhas[linhaParaAtualizar] = $"{id},{categoria},{descricao},{formVender.Qtd},{preco}";

                    // Escrever as alterações no arquivo
                    File.WriteAllLines(caminhoArquivo, linhas);
                    MessageBox.Show("Venda realizada com sucesso!!");

                    // Recarregar os dados no DataGridView
                    ExibirDados();
                }
                else
                {
                    MessageBox.Show("Erro ao encontrar o item para vender.");
                }
            }
            else
            {
                MessageBox.Show("Erro ao vender o item.");
            }

        }

        private void dataGridViewDados_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void tabelaVenda_Click(object sender, EventArgs e)
        {

        }
    }
}

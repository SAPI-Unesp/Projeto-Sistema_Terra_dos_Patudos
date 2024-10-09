using System;
using System.IO;
using System.Linq;
using System.Security;
using System.Windows.Forms;
using static System.Windows.Forms.LinkLabel;

namespace CadastroBanco
{
    public partial class Form2 : Form
    {
        string caminhoArquivo = "dados.txt"; // Arquivo onde os dados serão armazenados
        string caminhoArquivoVendas = "Vendas.txt"; // Arquivo onde os dados serão armazenados
        string caminhoArquivoCategoria = "categoria.txt";
        string caminhoArquivoCarrinho = "carrinho.txt";
        string itensComId = "itensComId.txt";
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
            linhas[index] = $"{nome}*{idade}"; // Atualiza o item selecionado

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

        public void VerificaExiste()
        {
            if (File.Exists(caminhoArquivo))
            {
                var linhas = File.ReadAllLines(caminhoArquivo);
                foreach (var linha in linhas)
                {
                    var dados = linha.Split('*');

                    // Certifique-se de que há 4 campos (categoria, descrição, quantidade, preço) // agr to pegando o id junto já q ele tá iterável
                    if (dados.Length == 6)
                    {
                        string id = dados[0].Trim();
                        string categoria = dados[1].Trim();
                        string descricao = dados[2].Trim();
                        string qnt = dados[3].Trim();
                        string preco = dados[4].Trim();
                        string data = dados[5].Trim();

                        // Adicionar os dados no DataGridView
                        dataGridViewDados.Rows.Add(id, categoria, descricao, qnt, preco, data);
                    }
                }
                dataGridViewDados.ClearSelection();
            }
            else
            {
                MessageBox.Show("Nenhum dado encontrado.");
            }

            if (File.Exists(caminhoArquivoCategoria))
            {
                var linhas = File.ReadAllLines(caminhoArquivoCategoria);
                foreach (var linha in linhas)
                {
                    bool contem = false;
                    foreach (var a in cbCategoria.Items)
                    {
                        if (a.Equals(linha))
                        {
                            contem = true;
                        }
                    }
                    if (!contem)
                    {
                        cbCategoria.Items.Add(linha);
                    }

                }
            }

        }
        private void Form2_Load(object sender, EventArgs e)
        {
            VerificaExiste();
            ExibirTudo();
           
        }

        private void btnAdicionar_Click_1(object sender, EventArgs e)
        {
            FormAdicionar formAdicionar = new FormAdicionar(this);
            formAdicionar.ShowDialog();
            VerificaExiste();
            cbCategoria.Text = formAdicionar.cbtexto;
            ExibirDados();
        }

        public void ExibirDados()
        {
           dataGridViewDados.Rows.Clear(); // Limpa as linhas antes de exibir

            if (File.Exists(caminhoArquivo))
            {
                var linhas = File.ReadAllLines(caminhoArquivo);
                foreach (var linha in linhas)
                {
                    var dados = linha.Split('*');

                    // Certifique-se de que há 4 campos (categoria, descrição, quantidade, preço) // agr to pegando o id junto já q ele tá iterável
                    if (dados.Length == 6)
                    {
                        string id = dados[0].Trim();
                        string categoria = dados[1].Trim();
                        string descricao = dados[2].Trim();
                        string qnt = dados[3].Trim();
                        string preco = dados[4].Trim();
                        string data = dados[5].Trim();

                        // Adicionar os dados no DataGridView
                        dataGridViewDados.Rows.Add(id , categoria, descricao, qnt, preco, data);
                    }
                }
            }
            else
            {
                MessageBox.Show("Nenhum dado encontrado.");
            }

            if (File.Exists(caminhoArquivoCategoria))
            {
                var linhas = File.ReadAllLines(caminhoArquivoCategoria);
                foreach (var linha in linhas)
                {
                    bool contem = false;
                    foreach(var a in cbCategoria.Items)
                    {
                        if(a.Equals(linha))
                        {
                            contem = true;
                        }
                    }
                    if(!contem)
                    {
                        cbCategoria.Items.Add(linha);
                    }

                }
            }


            foreach (DataGridViewRow row in dataGridViewDados.Rows)
            {
                string BuscaCat = cbCategoria.Text;
                string BuscaDes = row.Cells[1].Value.ToString();
                if (BuscaCat.ToLower().Equals(BuscaDes.ToLower()))
                {
                    //Deixa visivel as linhas que tem a classificação ou a descrição igual ao texto buscado
                    row.Visible = true;
                }
                else
                {
                    //Deixa invisivel as linhas que não tem a classificação ou a descrição igual ao texto buscado
                    row.Visible = false;
                }
                if (row.Cells[3].Value.ToString() == "0")
                {
                    row.Cells[6].Value = "Vendido";
                }
                else
                {
                    row.Cells[6].Value = "A Vender";
                }

            }


        }




        private void btnExibir_Click_1(object sender, EventArgs e)
        {

            ExibirTudo();

        }

        public void ExibirTudo()
        {
            cbCategoria.SelectedIndex = -1;

            foreach (DataGridViewRow row in dataGridViewDados.Rows)
            {
                row.Visible = true;
                if (row.Cells[3].Value.ToString() == "0")
                {
                    row.Cells[6].Value = "Vendido";
                }
                else
                {
                    row.Cells[6].Value = "A Vender";
                }
            }
            dataGridViewDados.ClearSelection();

        }

        private void btnAtualizar_Click_1(object sender, EventArgs e)
        {
            if (dataGridViewDados.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecione um item para atualizar.");
                return;
            }

            if (dataGridViewDados.SelectedRows.Count > 1)
            {
                MessageBox.Show("Selecione apenas um item.");
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
            string data = linhaSelecionada.Cells[5].Value.ToString();

            // Abrir o formulário de atualização com os dados atuais
            FormAtualizar formAtualizar = new FormAtualizar(categoria, descricao, qnt, preco);

            if (formAtualizar.ShowDialog() == DialogResult.OK)
            {
                // Se o usuário clicar em OK no formulário de atualização, realizar a atualização no arquivo

                // Ler todas as linhas do arquivo
                var linhas = File.ReadAllLines(caminhoArquivo).ToList();

                // Encontrar a linha correspondente pelo ID
                int linhaParaAtualizar = linhas.FindIndex(l => l.StartsWith(id + "*"));

                if (linhaParaAtualizar >= 0)
                {
                    // Atualizar a linha com os novos dados
                    linhas[linhaParaAtualizar] = $"{id}*{formAtualizar.Categoria}*{formAtualizar.Descricao}*{formAtualizar.Qnt}*{formAtualizar.Preco}*{data}";

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

          
            ExibirTudo();

        }

        private void btnDeletar_Click_1(object sender, EventArgs e)
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
                int linhaParaDeletar = linhas.FindIndex(l => l.StartsWith(id + "*"));
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
 
            ExibirTudo();
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
            if (dataGridViewDados.SelectedRows.Count > 1)
            {
                MessageBox.Show("Selecione apenas um item.");
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
            string data = linhaSelecionada.Cells[5].Value.ToString();
            FormVender formVender = new FormVender(qnt, preco);

            if(formVender.ShowDialog() == DialogResult.OK)
            {
                // Se o usuário clicar em OK no formulário de venda, realiza a atualização no arquivo

                // Ler todas as linhas do arquivo
                var linhas = File.ReadAllLines(caminhoArquivo).ToList();    

                // Encontrar a linha correspondente pelo ID
                int linhaParaAtualizar = linhas.FindIndex(l => l.StartsWith(id + "*"));

                if (linhaParaAtualizar >= 0)
                {
                    // Atualizar a linha com os novos dados
    
                    linhas[linhaParaAtualizar] = $"{id}*{categoria}*{descricao}*{formVender.Qtd}*{preco}*{data}";

                    // Escrever as alterações no arquivo
                    File.WriteAllLines(caminhoArquivo, linhas);
  
         
                    // Escrever as alterações no arquivo
                    int proximoId = ObterProximoIdDisponivel();
                   
                    File.AppendAllText(caminhoArquivoVendas, $"{proximoId}* {categoria}* {descricao}* {formVender.QtdV}*{preco*formVender.QtdV}*{DateTime.Now}*{formVender.nomeComprador}*{formVender.telefoneComprador}*{formVender.pagamento}{Environment.NewLine}");
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

            ExibirTudo();
        }

        /*
         * 
         * string categoria = cbCategoria.Text;
            string descricao = txtDesc.Text;
            decimal qnt = numQnt.Value;
            decimal preco = numPreco.Value;

            if (string.IsNullOrWhiteSpace(categoria))
            {
                MessageBox.Show("Preencha a categoria.");
                return;
            }

            int proximoId = ObterProximoIdDisponivel();

            // Adiciona ao arquivo
            File.AppendAllText(caminhoArquivo, $"{proximoId}* {categoria}* {descricao}* {qnt}* {preco}{Environment.NewLine}");
            MessageBox.Show("Dados adicionados com sucesso!");

            // Atualiza o DataGridView no formulário principal
            formPrincipal.ExibirDados();

            // Fecha o formulário de adição após a inserção
            this.Close();

         * */

        private int ObterProximoIdDisponivel()
        {
            // Se o arquivo não existir, o primeiro ID será 1
            if (!File.Exists(caminhoArquivoVendas))
                return 1;

            // Ler todas as linhas do arquivo
            var linhas = File.ReadAllLines(caminhoArquivoVendas);

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

        public void AddId()
        {
            var linhas2 = File.ReadAllLines(caminhoArquivo);
            string id;
            string categoria;
            string descricao;
            string qnt;
            string preco;
            string data;


            if (File.Exists(caminhoArquivo))
            {
                var linhas = File.ReadAllLines(caminhoArquivo);
                int i = 0;
                foreach (var linha in linhas)
                {
                    var dados = linha.Split('*');

                    // Certifique-se de que há 4 campos (categoria, descrição, quantidade, preço) // agr to pegando o id junto já q ele tá iterável
                  
                        File.AppendAllText(itensComId, $"{i}*{linha}{Environment.NewLine}");
                        i++;
                    

                   
           

                       
                 
                }
                dataGridViewDados.ClearSelection();
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

        private void tabelaVenda_Click(object sender, EventArgs e)
        {
            FormTabelaVenda form = new FormTabelaVenda();
            form.ShowDialog();
        }

        private void cbCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataGridViewDados.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            
                //Verifica se a classificação ou a descrição é igual ao texto buscado
                foreach (DataGridViewRow row in dataGridViewDados.Rows)
                {
                    string BuscaCat = cbCategoria.Text;
                    string BuscaDes = row.Cells[1].Value.ToString();
                    if (BuscaCat.ToLower().Equals(BuscaDes.ToLower()))
                    {
                        //Deixa visivel as linhas que tem a classificação ou a descrição igual ao texto buscado
                        row.Visible = true;
                    }
                    else
                    {
                        //Deixa invisivel as linhas que não tem a classificação ou a descrição igual ao texto buscado
                        row.Visible = false;
                    }
                }
        }

        private void btnAdcionarCarrinho_Click(object sender, EventArgs e)
        {
            dataGridViewDados.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            if (dataGridViewDados.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecione um item para adicionar ao carrinho.");
                return;
            }
            if (dataGridViewDados.SelectedRows.Count > 1)
            {
                MessageBox.Show("Selecione apenas um item.");
                return;
            }

            int index = dataGridViewDados.SelectedRows[0].Index;
            var linhaSelecionada = dataGridViewDados.Rows[index];

            if (File.Exists(caminhoArquivoCarrinho))
            {
                var linhas = File.ReadAllLines(caminhoArquivoCarrinho);

                foreach (var linha in linhas)
                {
                    var dados = linha.Split('*');
                    string id = dados[0].Trim();

                    if (linhaSelecionada.Cells[0].Value.ToString() == id)
                    {
                        MessageBox.Show("Esse produto já está no carrinho!!");
                        return;
                    }
                }

                File.AppendAllText(caminhoArquivoCarrinho, $"{linhaSelecionada.Cells[0].Value.ToString()}{Environment.NewLine}");
                MessageBox.Show("Produto adicionado ao carrinho com sucesso!");
            }
            else
            {
                File.AppendAllText(caminhoArquivoCarrinho, $"{linhaSelecionada.Cells[0].Value.ToString()}{Environment.NewLine}");
                MessageBox.Show("Produto adicionado ao carrinho com sucesso!");
            }

            dataGridViewDados.ClearSelection();
        }

        private void btnVisualizarCarrinho_Click(object sender, EventArgs e)
        {
            FormVisualizarCarrinho formVisualizar = new FormVisualizarCarrinho();
            formVisualizar.ShowDialog();
        }
    }
}

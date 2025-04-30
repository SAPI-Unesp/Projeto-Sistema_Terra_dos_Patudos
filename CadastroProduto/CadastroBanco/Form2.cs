using MySqlX.XDevAPI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security;
using System.Windows.Forms;
using static System.Windows.Forms.LinkLabel;
using System.Drawing;
using Excel = Microsoft.Office.Interop.Excel;
using System.Reflection;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.InteropServices;
using Microsoft.Office.Interop.Excel;

namespace CadastroBanco
{
    public partial class Form2 : Form
    {
        string caminhoArquivo = "dados.txt"; // Arquivo onde os dados serão armazenados
        string caminhoArquivoVendas = "Vendas.txt"; // Arquivo onde os dados serão armazenados
        string caminhoArquivoCategoria = "categoria.txt";
        string caminhoArquivoCarrinho = "carrinho.txt";
        string caminhoArquivoCliente = "cliente.txt";
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
            if (!System.Windows.Forms.SystemInformation.TerminalServerSession)
            {
                Type dgvType = dataGridViewDados.GetType();
                PropertyInfo pi = dgvType.GetProperty("DoubleBuffered",
                BindingFlags.Instance | BindingFlags.NonPublic);
                pi.SetValue(dataGridViewDados, true, null);
            }
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
                    if (dados.Length == 9)
                    {
                        string id = dados[0].Trim();
                        string livroid = dados[1].Trim();
                        string categoria = dados[2].Trim();
                        string descricao = dados[3].Trim();
                        string qnt = dados[4].Trim();
                        string preco = dados[5].Trim();
                        string data = dados[6].Trim();
                        string venda = dados[7].Trim();
                        // Adicionar os dados no DataGridView
                        dataGridViewDados.Rows.Add(id, livroid, categoria, descricao, qnt, preco, data, venda);
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
            AddCliente();
            VerificaExiste();
            ExibirTudo();
            System.Drawing.Rectangle workingRectangle = Screen.PrimaryScreen.WorkingArea;
            this.Size = new System.Drawing.Size(Convert.ToInt32(0.5 * workingRectangle.Width),
                Convert.ToInt32(0.5 * workingRectangle.Height));

            this.Location = new System.Drawing.Point(10, 10);
            //AddId();
            System.Drawing.Font headerFont = new System.Drawing.Font("Arial", 10, FontStyle.Bold); // Fonte para cabeçalhos
            dataGridViewDados.ColumnHeadersDefaultCellStyle.Font = headerFont;
            // Definindo o estilo de fonte para todas as células
            System.Drawing.Font cellFont = new System.Drawing.Font("Arial", 10, FontStyle.Bold); // Ajuste o tamanho conforme necessário
            dataGridViewDados.DefaultCellStyle.Font = cellFont;

            ExibirDados();
            ExibirTudo();


        }

        private void btnAdicionar_Click_1(object sender, EventArgs e)
        {
            FormAdicionar formAdicionar = new FormAdicionar(this);
            formAdicionar.ShowDialog();
            VerificaExiste();
            cbCategoria.Text = formAdicionar.cbtexto;
            ExibirDados();
            ExibirTudo();
        }

        public void ExibirDados()
        {
            dataGridViewDados.Rows.Clear(); // Limpa as linhas antes de exibir
            double totalQnt = 0;
            if (File.Exists(caminhoArquivo))
            {
                var linhas = File.ReadAllLines(caminhoArquivo);
                foreach (var linha in linhas)
                {
                    var dados = linha.Split('*');

                    // Certifique-se de que há 9 campos
                    if (dados.Length == 9)
                    {
                        string id = dados[0].Trim();
                        string livroId = dados[1].Trim();
                        string categoria = dados[2].Trim();
                        string descricao = dados[3].Trim();
                        string qnt = dados[4].Trim();
                        string preco = dados[5].Trim();
                        string data = dados[6].Trim();
                        string venda = dados[7].Trim();
                   
                        totalQnt += Convert.ToDouble(qnt);
                        // Adicionar os dados no DataGridView
                        int rowIndex = 0;
                        if (Convert.ToInt32(qnt) == 0)
                        {
                            rowIndex = dataGridViewDados.Rows.Add(id, livroId, categoria, descricao, qnt, preco, data, "vendida");
                            venda = "vendida";
                        }
                        else
                        {
                            rowIndex = dataGridViewDados.Rows.Add(id, livroId, categoria, descricao, qnt, preco, data, venda);
                        }

                        DataGridViewRow row = dataGridViewDados.Rows[rowIndex];

                        // Definindo a cor de fundo com base no status da venda
                        if (venda.Equals("a vender", StringComparison.OrdinalIgnoreCase))
                        {
                            row.DefaultCellStyle.BackColor = Color.FromArgb(220, 220, 255); // Cor pastel para "A Vender"
                        }
                        else if (venda.Equals("vendida", StringComparison.OrdinalIgnoreCase) && Convert.ToInt32(qnt) == 0)
                        {
                            row.DefaultCellStyle.BackColor = Color.FromArgb(255, 220, 220); // Cor pastel para "Vendido"
                        }
                        else if (venda.Equals("vendida", StringComparison.OrdinalIgnoreCase) && Convert.ToInt32(qnt) != 0)
                        {
                            row.DefaultCellStyle.BackColor = Color.FromArgb(236, 167, 167);
                        }
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

            // Filtrando linhas com base na categoria
            foreach (DataGridViewRow row in dataGridViewDados.Rows)
            {
                string BuscaCat = cbCategoria.Text;
                string BuscaDes = row.Cells[1].Value.ToString();
                row.Visible = BuscaCat.ToLower().Equals(BuscaDes.ToLower());
            }
            textQnt.Text = totalQnt.ToString();
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
                    string precoVenda = dadosVenda[6].Trim();
                    string pessoa = dadosVenda[8].Trim();
                    string telefonep = dadosVenda[9].Trim();

                    bool clienteExistente = false;

                    for (int j = 0; j < linhasClientes.Count; j++)
                    {
                        var dadosCliente = linhasClientes[j].Split('*');
                        string cliente = dadosCliente[1].Trim();
                        string telefone = dadosCliente[2].Trim();
                        string desconto = dadosCliente[4].Trim();
                        string credito = "0";

                        if (pessoa.Equals(cliente))
                        {
                            clienteExistente = true;


                            linhasClientes[j] = $"{j}*{cliente}*{telefone}*0*{desconto}*{credito}";

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
                string credito = "0";
                decimal valorDivida = 0;

                foreach (var linhaV in linhasVendas)
                {
                    var dadosVenda = linhaV.Split('*');

                    if (dadosVenda.Length >= 10)
                    {
                        string precoVenda = dadosVenda[6].Trim();
                        string pessoa = dadosVenda[8].Trim();

                        if (pessoa.Equals(cliente))
                        {
                            valorDivida += decimal.Parse(precoVenda);
                        }
                    }
                }
                int linhasParaAtualizar = linhasClientes.FindIndex(l => l.StartsWith(id + "*"));

                linhasCliente2[linhasParaAtualizar] = $"{id}*{cliente}*{telefone}*{valorDivida.ToString()}*{desconto}*{credito}";
            }

            File.WriteAllLines(caminhoArquivoCliente, linhasCliente2);
        }
        private void btnExibir_Click_1(object sender, EventArgs e)
        {
            ExibirDados();
            ExibirTudo();

        }

        public void ExibirTudo()
        {
            cbCategoria.SelectedIndex = -1;

            foreach (DataGridViewRow row in dataGridViewDados.Rows)
            {
                row.Visible = true;
                /*if (row.Cells[4].Value.ToString() == "0")
                {
                    row.Cells[6].Value = "Vendido";
                }
                else
                {
                    row.Cells[6].Value = "A Vender";
                }*/
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
            string livroId = linhaSelecionada.Cells[1].Value.ToString();
            string categoria = linhaSelecionada.Cells[2].Value.ToString();
            string descricao = linhaSelecionada.Cells[3].Value.ToString();
            decimal qnt = decimal.Parse(linhaSelecionada.Cells[4].Value.ToString());
            decimal preco = decimal.Parse(linhaSelecionada.Cells[5].Value.ToString());
            string data = linhaSelecionada.Cells[6].Value.ToString();
            string venda = linhaSelecionada.Cells[7].Value.ToString();

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
                    linhas[linhaParaAtualizar] = $"{id}*{livroId}*{formAtualizar.Categoria}*{formAtualizar.Descricao}*{formAtualizar.Qnt}*{formAtualizar.Preco}*{data}*{venda}*";

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
            Buscar2();

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

        public static int LevenshteinDistance(string s1, string s2)
        {
            int[,] matrix = new int[s1.Length + 1, s2.Length + 1];

            for (int i = 0; i <= s1.Length; i++)
                matrix[i, 0] = i;

            for (int j = 0; j <= s2.Length; j++)
                matrix[0, j] = j;

            for (int i = 1; i <= s1.Length; i++)
            {
                for (int j = 1; j <= s2.Length; j++)
                {
                    int cost = (s1[i - 1] == s2[j - 1]) ? 0 : 1;
                    matrix[i, j] = Math.Min(
                        Math.Min(matrix[i - 1, j] + 1, matrix[i, j - 1] + 1),
                        matrix[i - 1, j - 1] + cost);
                }
            }

            return matrix[s1.Length, s2.Length];
        }

        public static string removerAcentos(string texto)
        {
            string comAcentos = "ÄÅÁÂÀÃäáâàãÉÊËÈéêëèÍÎÏÌíîïìÖÓÔÒÕöóôòõÜÚÛüúûùÇç";
            string semAcentos = "AAAAAAaaaaaEEEEeeeeIIIIiiiiOOOOOoooooUUUuuuuCc";

            for (int i = 0; i < comAcentos.Length; i++)
            {
                texto = texto.Replace(comAcentos[i].ToString(), semAcentos[i].ToString());
            }
            return texto;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {/*
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

                foreach (DataGridViewRow row in dataGridViewDados.Rows)
                {
                    row.Visible = false;
                }

                //Verifica se a classificação ou a descrição é igual ao texto buscado
                foreach (DataGridViewRow row in dataGridViewDados.Rows)
                {
                    string BuscaDes = row.Cells[3].Value.ToString().Normalize();
                    string BuscaNomalizada = removerAcentos(BuscaDes);
                    var dados = BuscaDes.Split(' ');
                    var buscaTexto = Busca.Split(' ');
                    bool canExibir = true;
                    foreach (var a in buscaTexto)
                    {

                        string teste = removerAcentos(a);
                        if (BuscaNomalizada.ToLower().Contains(teste.ToLower()))
                        {

                        }
                        else
                        {
                            canExibir = false;
                        }

                    }
                    if (canExibir)
                    {
                        row.Visible = true;
                        row.Selected = true;
                    }

                    BuscaDes = row.Cells[1].Value.ToString().Normalize();
                    BuscaNomalizada = removerAcentos(BuscaDes);
                    canExibir = true;
                    foreach (var a in buscaTexto)
                    {

                        string teste = removerAcentos(a);
                        if (BuscaNomalizada.ToLower().Contains(teste.ToLower()))
                        {

                        }
                        else
                        {
                            canExibir = false;
                        }

                    }
                    if (canExibir)
                    {
                        row.Visible = true;
                        row.Selected = true;
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
                ExibirTudo();
                MessageBox.Show("Nenhum item encontrado.");
                return;
            }
            else
            {
                dataGridViewDados.ClearSelection();
                return;
            }
            */

        }

        public void Buscar2()
        {
            //Desseleciona os itens selecionados da tabela
            dataGridViewDados.ClearSelection();

            //Verifica se tem algum texto na busca
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                return;
            }

            string Busca = textBox1.Text;


            dataGridViewDados.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            try
            {

                foreach (DataGridViewRow row in dataGridViewDados.Rows)
                {
                    row.Visible = false;
                }

                //Verifica se a classificação ou a descrição é igual ao texto buscado
                foreach (DataGridViewRow row in dataGridViewDados.Rows)
                {
                    string BuscaDes = row.Cells[2].Value.ToString().Normalize();
                    string BuscaNomalizada = removerAcentos(BuscaDes);
                    var dados = BuscaDes.Split(' ');
                    var buscaTexto = Busca.Split(' ');
                    bool canExibir = true;
                    foreach (var a in buscaTexto)
                    {

                        string teste = removerAcentos(a);
                        if (BuscaNomalizada.ToLower().Contains(teste.ToLower()))
                        {

                        }
                        else
                        {
                            canExibir = false;
                        }

                    }
                    if (canExibir)
                    {
                        row.Visible = true;
                        row.Selected = true;
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
                ExibirTudo();
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
        {/*
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

            if (formVender.ShowDialog() == DialogResult.OK)
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

                    File.AppendAllText(caminhoArquivoVendas, $"{proximoId}* {categoria}* {descricao}* {formVender.QtdV}*{preco * formVender.QtdV}*{DateTime.Now}*{formVender.nomeComprador}*{formVender.telefoneComprador}*{formVender.pagamento}{Environment.NewLine}");
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

            ExibirTudo();*/
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
            var linhasVendas = File.ReadAllLines(caminhoArquivoVendas);
            var linhasLivros = File.ReadAllLines(caminhoArquivo);

            int i = 0;
            bool encontrou = false;
            double dividaTotal = 0;
            double desconto = 0;
            var linhasProcessadas = new HashSet<string>();

            foreach (var linhaVenda in linhasVendas)
            {
                var dadosVenda = linhaVenda.Split('*');
                if (dadosVenda.Length >= 9)
                {
                    string categoriaVenda = dadosVenda[1].Trim();
                    string descricaoVenda = dadosVenda[2].Trim();
                    string qntVenda = dadosVenda[3].Trim();
                    string precoVenda = dadosVenda[4].Trim();
                    string dataVenda = dadosVenda[5].Trim();
                    string pessoa = dadosVenda[6].Trim();
                    string telefone = dadosVenda[7].Trim();
                    string pendente = dadosVenda[8].Trim();



                    // Monta a linha com os campos corretos
                    string linhaSaida = $"{i}*{pessoa}*{dividaTotal}*{desconto}{Environment.NewLine}";

                    File.AppendAllText(itensComId, linhaSaida);

                    linhasProcessadas.Add(linhaVenda);
                }
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
                string BuscaDes = row.Cells[2].Value.ToString();
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
            /*dataGridViewDados.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

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

            dataGridViewDados.ClearSelection();*/
        }

        private void btnVisualizarCarrinho_Click(object sender, EventArgs e)
        {
            /*FormVisualizarCarrinho formVisualizar = new FormVisualizarCarrinho();
            if (File.Exists(caminhoArquivoCarrinho))
            {
                if (formVisualizar.ShowDialog() == DialogResult.OK)
                {
                    ExibirDados();
                    ExibirTudo();
                }
            }
            else
            {
                MessageBox.Show("Nenhum item no carrinho");
            }*/
        }

        private void btnCliente_Click(object sender, EventArgs e)
        {
            FormClientes formCliente = new FormClientes();

            if (File.Exists(caminhoArquivoCliente))
            {
                if (formCliente.ShowDialog() == DialogResult.OK)
                {
                    ExibirDados();
                    ExibirTudo();
                }
            }
            else
            {
                MessageBox.Show("Nenhum cliente cadastrado");
            }
        }

        private void copyAlltoClipboard()
        {
            dataGridViewDados.SelectAll();
            DataObject dataObj = dataGridViewDados.GetClipboardContent();
            if (dataObj != null)
                Clipboard.SetDataObject(dataObj);
        }

        private void releaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
                MessageBox.Show("Exception Occurred while releasing object " + ex.ToString());
            }
            finally
            {
                GC.Collect();
            }
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel.Workbook workbook = excel.Workbooks.Add(System.Reflection.Missing.Value);
            Microsoft.Office.Interop.Excel.Worksheet sheet1 = (Microsoft.Office.Interop.Excel.Worksheet)workbook.Sheets[1];

            var formProgresso = new FormVender();
            formProgresso.Show();

            try
            {

                System.Drawing.Font headerFont = new System.Drawing.Font("Arial", 10, FontStyle.Bold); // Fonte para cabeçalhos
                sheet1.Cells.Font.Size = 9;

               


                BackgroundWorker worker = new BackgroundWorker();
                worker.WorkerReportsProgress = true;
                    worker.WorkerSupportsCancellation = true;
                worker.DoWork += (s, args) =>
                {


                    int StartCol = 1;
                    int StartRow = 1;
                    int j = 0, i = 0;


                    //Write Headers
                    for (j = 1; j < dataGridViewDados.Columns.Count; j++)
                    {
                        if (formProgresso.Cancelar == true)
                        {
                            args.Cancel = true;
                            return;
                        }
                        Microsoft.Office.Interop.Excel.Range myRange = (Microsoft.Office.Interop.Excel.Range)sheet1.Cells[StartRow, StartCol + (j - 1)];
                        if (dataGridViewDados.Columns[j].HeaderText == "Quantidade em Estoque")
                            myRange.Value2 = "QTDE";
                        else if (dataGridViewDados.Columns[j].HeaderText == "Pag do Livro")
                            myRange.Value2 = "Pag";

                        else
                            myRange.Value2 = dataGridViewDados.Columns[j].HeaderText;

                        myRange.Columns.AutoFit();
                        myRange.Interior.Color = ColorTranslator.ToOle(Color.FromArgb(93, 173, 226));
                        myRange.Borders.Color = ColorTranslator.ToOle(Color.FromArgb(0, 0, 0));
                        myRange.Font.Bold = true;

                        worker.ReportProgress(0, $"Exportando cabeçalhos....");

                        sheet1.Cells[StartRow, j].HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                    }

                    StartRow++;

                    //Write datagridview content
                    for (i = 1; i < dataGridViewDados.Rows.Count; i++)
                    {
                        sheet1.Columns.AutoFit();
                        for (j = 1; j < dataGridViewDados.Columns.Count; j++)
                        {
                            try
                            {
                                Microsoft.Office.Interop.Excel.Range myRange = (Microsoft.Office.Interop.Excel.Range)sheet1.Cells[StartRow + (i - 1), StartCol + (j - 1)];

                                if (j == 1)
                                    myRange.NumberFormat = "@";

                                myRange.Value2 = dataGridViewDados[j, i].Value == null ? "" : dataGridViewDados[j, i].Value;
                                sheet1.Cells[i + 1, j].HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

                                int progresso = (int)((double)i / dataGridViewDados.Rows.Count * 100);
                                worker.ReportProgress(progresso, $"Exportando linhas {i} de {dataGridViewDados.Rows.Count}");
                                
                            }
                            catch
                            {
                                ;
                            }
                        }
                    }

                };

                worker.ProgressChanged += (s, args) =>
                {
                    formProgresso.AttBar(args.ProgressPercentage, (string) args.UserState);
                };
                worker.RunWorkerCompleted += (s, args) =>
                {
                    formProgresso.Close();

                    if (!args.Cancelled)
                    {
                        excel.Visible = true;
                        Marshal.ReleaseComObject(sheet1);
                        Marshal.ReleaseComObject(workbook);
                        Marshal.ReleaseComObject(excel);
                    }
                    else
                    {
                        CleanupExcel(excel, workbook, sheet1);
                    }

                };
                worker.RunWorkerAsync();
              
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                CleanupExcel(excel, workbook, sheet1);
                formProgresso.Close();
            }
            
        }
        private void CleanupExcel(Microsoft.Office.Interop.Excel.Application excel, Microsoft.Office.Interop.Excel.Workbook workbook, Microsoft.Office.Interop.Excel.Worksheet sheet1)
        {
            try
            {
                if (workbook != null)
                {
                    workbook.Close(false);
                    Marshal.ReleaseComObject(workbook);
                }
                if (excel != null)
                {
                    excel.Quit();
                    Marshal.ReleaseComObject(excel);
                }
                if (sheet1 != null)
                {
                    Marshal.ReleaseComObject(sheet1);
                }
            }
            finally
            {
                GC.Collect();
                GC.WaitForPendingFinalizers();
            }
        }

        private void Worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void imgAddCarrinho_Click(object sender, EventArgs e)
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

        private void imgVerCarrinho_Click(object sender, EventArgs e)
        {
            FormVisualizarCarrinho formVisualizar = new FormVisualizarCarrinho();
            if (File.Exists(caminhoArquivoCarrinho))
            {
                if (formVisualizar.ShowDialog() == DialogResult.OK)
                {
                    ExibirDados();
                    ExibirTudo();
                }
            }
            else
            {
                MessageBox.Show("Nenhum item no carrinho");
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
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

                foreach (DataGridViewRow row in dataGridViewDados.Rows)
                {
                    row.Visible = false;
                }

                //Verifica se a classificação ou a descrição é igual ao texto buscado
                foreach (DataGridViewRow row in dataGridViewDados.Rows)
                {
                    string BuscaDes = row.Cells[3].Value.ToString().Normalize();
                    string BuscaNomalizada = removerAcentos(BuscaDes);
                    var dados = BuscaDes.Split(' ');
                    var buscaTexto = Busca.Split(' ');
                    bool canExibir = true;
                    foreach (var a in buscaTexto)
                    {

                        string teste = removerAcentos(a);
                        if (BuscaNomalizada.ToLower().Contains(teste.ToLower()))
                        {

                        }
                        else
                        {
                            canExibir = false;
                        }

                    }
                    if (canExibir)
                    {
                        row.Visible = true;
                        row.Selected = true;
                    }

                    BuscaDes = row.Cells[1].Value.ToString().Normalize();
                    BuscaNomalizada = removerAcentos(BuscaDes);
                    canExibir = true;
                    foreach (var a in buscaTexto)
                    {

                        string teste = removerAcentos(a);
                        if (BuscaNomalizada.ToLower().Contains(teste.ToLower()))
                        {

                        }
                        else
                        {
                            canExibir = false;
                        }

                    }
                    if (canExibir)
                    {
                        row.Visible = true;
                        row.Selected = true;
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
                ExibirTudo();
                MessageBox.Show("Nenhum item encontrado.");
                return;
            }
            else
            {
                dataGridViewDados.ClearSelection();
                return;
            }

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            
            /*Process.Start(new ProcessStartInfo("https://www.youtube.com/playlist?list=PLhEZRWtYRMyt4enwYFTX7io5NHKbluSaG")
            {UseShellExecute = true});*/
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Process.Start(new ProcessStartInfo("https://www.youtube.com/watch?v=skhtgRXdeys&list=PLhEZRWtYRMyt4enwYFTX7io5NHKbluSaG&index")
            { UseShellExecute = true });
        }
    }
}

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
using System.Reflection;
using System.Diagnostics;
using Excel = Microsoft.Office.Interop.Excel;
using System.Runtime.InteropServices;
namespace CadastroBanco
{
    public partial class FormTabelaVenda : Form
    {
        decimal valorTotal = 0;
        string caminhoArquivoVendas = "Vendas.txt";
        string caminhoArquivo = "dados.txt";
        string caminhoArquivoCliente = "cliente.txt";
        DateTime data1;
        DateTime data2;
        public FormTabelaVenda()
        {
            InitializeComponent();
            DateTime data1 = new DateTime();
            data1 = dataPickerStart.Value;

            dataPickerStart.Format = DateTimePickerFormat.Custom;
            dataPickerStart.CustomFormat = "MMMM/yyyy"; // Exibe apenas mês e ano
            dataPickerStart.ShowUpDown = true; // Permite alterar mês/ano com setas

            cbPessoas.Items.Add("(Todos)");
            cbPessoas.SelectedIndex = 0;
            cbPagamento.SelectedIndex = 0;
            checkBox1.Checked = false;

            if (!System.Windows.Forms.SystemInformation.TerminalServerSession)
            {
                Type dgvType = dataGridViewDados.GetType();
                PropertyInfo pi = dgvType.GetProperty("DoubleBuffered",
                BindingFlags.Instance | BindingFlags.NonPublic);
                pi.SetValue(dataGridViewDados, true, null);
            }
            
            Pagamento();
            ExibirPessoa();
            ExibirPessoa();
            Pagamento();
            valorTotalDesconto();
            //ExibirDados();
        }



        private void dataGridViewDados_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridViewDados.SelectedRows.Count > 0) 
                mesesComboBox.Visible = true;
            mesesComboBox.Visible = true;
       
        }

        private void dataGridViewDados_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewDados.SelectedRows.Count > 0)
            {
                mesesComboBox.Visible = true;
            }
            else
            {
                //mesesComboBox.Visible = false; // Opcional, caso queira esconder quando nada estiver selecionado
            }
        }
       
        public void ExibirDados()
        {

            dataGridViewDados.Rows.Clear(); // Limpa as linhas antes de exibir
            valorTotal = 0;
            if (File.Exists(caminhoArquivoVendas))
            {
                var linhas = File.ReadAllLines(caminhoArquivoVendas);
                foreach (var linha in linhas)
                {
                    var dados = linha.Split('*');
                    bool temNome = false;
                    // Certifique-se de que há 10 campos (categoria, descrição, quantidade, preço) // agr to pegando o id junto já q ele tá iterável
                    if (dados.Length == 11)
                    {
                        string id = dados[0].Trim();
                        string idVenda = dados[1].Trim();
                        string idLivro = dados[2].Trim();
                        string categoria = dados[3].Trim();
                        string descricao = dados[4].Trim();
                        string qnt = dados[5].Trim();
                        string preco = dados[6].Trim();
                        string data = dados[7].Trim();
                        string nome = dados[8].Trim();
                        string telefone = dados[9].Trim();
                        string pagamento = dados[10].Trim();
                        // Adicionar os dados no DataGridView
                        dataGridViewDados.Rows.Add(id, idVenda, idLivro, categoria, descricao, qnt, preco, data, nome, telefone, pagamento);
                        valorTotal += Convert.ToDecimal(preco);
                        foreach (var nomes in cbPessoas.Items)
                        {
                            if (nomes.Equals(nome))
                            {
                                temNome = true;
                            }
                        }
                        if (!temNome)
                        {
                            cbPessoas.Items.Add(nome);
                        }

                    }

                }
                txtTotal.Text = "R$ " + valorTotal.ToString();
                dataGridViewDados.ClearSelection();
            }
            else
            {
                MessageBox.Show("Nenhum dado encontrado.");
            }
        }

        public void ExibirPessoa()
        {
            ExibirDados();

            valorTotal = 0;
            dataGridViewDados.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            if (cbPessoas.Text == "(Todos)")
            {
                foreach (DataGridViewRow row in dataGridViewDados.Rows)
                {
                    DateTime cellDate;
                    bool check = checkBox1.Checked;
                    if (check)
                    {
                        if (DateTime.TryParse(row.Cells[7].Value?.ToString(), out cellDate))
                        {
                            // Compara apenas mês e ano
                            if (cellDate.Month == dataPickerStart.Value.Month && cellDate.Year == dataPickerStart.Value.Year)
                            {
                                row.Visible = true;
                                valorTotal += Convert.ToDecimal(row.Cells[6].Value.ToString());
                            }
                            else
                            {
                                row.Visible = false;
                            }
                        }
                        else
                        {
                            row.Visible = false;
                        }
                    }
                    else
                    {
                        row.Visible = true;
                        valorTotal += Convert.ToDecimal(row.Cells[6].Value.ToString());
                    }
                }
            }
            else
            {
                foreach (DataGridViewRow row in dataGridViewDados.Rows)
                {

                    if (row.Cells[8].Value != null &&
                        row.Cells[8].Value.ToString().Equals(cbPessoas.Text))
                    {
                        DateTime cellDate;
                        bool check = checkBox1.Checked;
                        if (check)
                        {
                            if (DateTime.TryParse(row.Cells[7].Value?.ToString(), out cellDate))
                            {
                                if (cellDate.Month == dataPickerStart.Value.Month && cellDate.Year == dataPickerStart.Value.Year)
                                {
                                    row.Visible = true;
                                    valorTotal += Convert.ToDecimal(row.Cells[6].Value.ToString());
                                }
                                else
                                {
                                    row.Visible = false;
                                }
                            }
                            else
                            {
                                row.Visible = false;
                            }
                        }
                        else
                        {
                            row.Visible = true;
                            valorTotal += Convert.ToDecimal(row.Cells[6].Value.ToString());
                        }
                    }
                    else
                    {
                        row.Visible = false;
                    }



                }
            }
            txtTotal.Text = "R$ " + valorTotal.ToString();
        }

        public void valorTotalDesconto()
        {
            var total = txtTotal.Text.Split(' ');
            decimal valorTotal = decimal.Parse(total[1]);
            decimal divida = valorTotal;
            string pessoa = cbPessoas.Text;


            var linhasClientes = File.ReadAllLines(caminhoArquivoCliente);

            foreach (var linhaCliente in linhasClientes)
            {
                var dadosCliente = linhaCliente.Split('*');
                string cliente = dadosCliente[1].Trim();
                string telefone = dadosCliente[2].Trim();
                string valorDivida = dadosCliente[3].Trim();
                string desconto = dadosCliente[4].Trim();
                string credito = "0";

                decimal descont = Convert.ToDecimal(desconto);
                
                //ignorar data
                if(!checkBox1.Checked)
                {
                    if (pessoa == cliente && cbPagamento.Text != "Realizado")
                    {
                        divida -= descont;
                       

                    }
                    else if (pessoa == "(Todos)" && cbPagamento.Text == "(Todos)")
                    {
                        divida -= descont;
                     
                    }
                }
                else
                {
                    
                }
                
            }
            if (divida < 0)
            {
                divida = 0;
            }
            //txtDesconto.Text = "R$ " + divida.ToString();
        }
        
        private void FormTabelaVenda_Load(object sender, EventArgs e)
        {
            
            /*System.Drawing.Rectangle workingRectangle = Screen.PrimaryScreen.WorkingArea;
            this.Size = new System.Drawing.Size(Convert.ToInt32(0.5 * workingRectangle.Width),
                Convert.ToInt32(0.5 * workingRectangle.Height));

            this.Location = new System.Drawing.Point(10, 10);


            this.Width = 1280;
            this.Height = 720;*/

            AddCliente();
            valorTotalDesconto();

            mesesComboBox.Visible = false;

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
                        string precoVenda = dadosVenda[5].Trim();
                        string pessoa = dadosVenda[8].Trim();
                        string pendenteRealizado = dadosVenda[10].Trim();

                        if (pessoa.Equals(cliente))
                        {
                            if(pendenteRealizado == "Pendente")
                                valorDivida += decimal.Parse(precoVenda);
                        }
                    }
                }
                int linhasParaAtualizar = linhasClientes.FindIndex(l => l.StartsWith(id + "*"));

                linhasCliente2[linhasParaAtualizar] = $"{id}*{cliente}*{telefone}*{valorDivida.ToString()}*{desconto}*{credito}";
            }

            File.WriteAllLines(caminhoArquivoCliente, linhasCliente2);
        }


        private void cbPessoas_SelectedIndexChanged(object sender, EventArgs e)
        {
            mesesComboBox.Visible = false;

            ExibirPessoa();
            Pagamento();
            valorTotalDesconto();
        }



        private void dataPickerStart_ValueChanged(object sender, EventArgs e)
        {


            Pagamento();
            ExibirPessoa();

            ExibirPessoa();
            Pagamento();
            //valorTotalDesconto();

            mesesComboBox.Visible = false;
        }

        public void Pagamento()
        {
            Font headerFont = new Font("Arial", 10, FontStyle.Bold); // Fonte para cabeçalhos
            dataGridViewDados.ColumnHeadersDefaultCellStyle.Font = headerFont;
            // Definindo o estilo de fonte para todas as células
            Font cellFont = new Font("Arial", 10, FontStyle.Bold); // Ajuste o tamanho conforme necessário
            dataGridViewDados.DefaultCellStyle.Font = cellFont;

            valorTotal = 0;
            Dictionary<DateTime, Color> colorMap = new Dictionary<DateTime, Color>();
            Random random = new Random();

            foreach (DataGridViewRow row in dataGridViewDados.Rows)
            {
                string value = cbPagamento.Text;
                string pagamento = row.Cells[10].Value?.ToString();
                string nome = row.Cells[8].Value?.ToString();
                bool check = checkBox1.Checked;
                bool exibeLinha = (pagamento == value);
                DateTime cellDate;

                if (value == "(Todos)")
                {
                    if (check)
                    {
                        if (cbPessoas.Text == "(Todos)")
                        {
                            if (DateTime.TryParse(row.Cells[7].Value?.ToString(), out cellDate))
                            {
                                if (cellDate.Month == dataPickerStart.Value.Month && cellDate.Year == dataPickerStart.Value.Year)
                                {
                                    row.Visible = true;
                                    valorTotal += Convert.ToDecimal(row.Cells[6].Value.ToString());

                                    // Define a cor da linha
                                    if (!colorMap.ContainsKey(cellDate))
                                    {
                                        Color pastelColor = Color.FromArgb(
                                            random.Next(200, 256), // Red
                                            random.Next(200, 256), // Green
                                            random.Next(200, 256)  // Blue
                                        );
                                        colorMap[cellDate] = pastelColor;
                                    }
                                    row.DefaultCellStyle.BackColor = colorMap[cellDate];
                                }
                                else
                                {
                                    row.Visible = false;
                                }
                            }
                            else
                            {
                                row.Visible = false;
                            }
                            if (row.Cells[10].Value.ToString() == "Pendente")
                            {
                                row.Cells[10].Style.ForeColor = Color.FromArgb(156, 0, 0);
                            }
                            else if(row.Cells[10].Value.ToString() == "Realizado")
                            {
                                row.Cells[10].Style.ForeColor = Color.FromArgb(0, 156, 0);
                            }
                            else
                            {
                                row.Cells[10].Style.ForeColor = Color.FromArgb(0, 0, 156);
                            }
                        }
                        else if (row.Cells[8].Value != null && row.Cells[8].Value.ToString().Equals(cbPessoas.Text))
                        {
                            if (DateTime.TryParse(row.Cells[7].Value?.ToString(), out cellDate))
                            {
                                if (cellDate.Month == dataPickerStart.Value.Month && cellDate.Year == dataPickerStart.Value.Year)
                                {
                                    row.Visible = true;
                                    valorTotal += Convert.ToDecimal(row.Cells[6].Value.ToString());

                                    if (!colorMap.ContainsKey(cellDate))
                                    {
                                        Color pastelColor = Color.FromArgb(
                                            random.Next(200, 256), // Red
                                            random.Next(200, 256), // Green
                                            random.Next(200, 256)  // Blue
                                        );
                                        colorMap[cellDate] = pastelColor;
                                    }
                                    row.DefaultCellStyle.BackColor = colorMap[cellDate];
                                }
                                else
                                {
                                    row.Visible = false;
                                }
                            }
                            else
                            {
                                row.Visible = false;
                            }
                            if (row.Cells[10].Value.ToString() == "Pendente")
                            {
                                row.Cells[10].Style.ForeColor = Color.FromArgb(156, 0, 0);
                            }
                            else if (row.Cells[10].Value.ToString() == "Realizado")
                            {
                                row.Cells[10].Style.ForeColor = Color.FromArgb(0, 156, 0);
                            }
                            else
                            {
                                row.Cells[10].Style.ForeColor = Color.FromArgb(0, 0, 156);
                            }
                        }
                    }
                    else
                    {
                        if (cbPessoas.Text == "(Todos)")
                        {
                            row.Visible = true;
                            valorTotal += Convert.ToDecimal(row.Cells[6].Value.ToString());

                            if (DateTime.TryParse(row.Cells[7].Value?.ToString(), out cellDate))
                            {
                                if (!colorMap.ContainsKey(cellDate))
                                {
                                    Color pastelColor = Color.FromArgb(
                                        random.Next(200, 256), // Red
                                        random.Next(200, 256), // Green
                                        random.Next(200, 256)  // Blue
                                    );
                                    colorMap[cellDate] = pastelColor;
                                }
                                row.DefaultCellStyle.BackColor = colorMap[cellDate];
                            }
                        }
                        else if (row.Cells[8].Value != null && row.Cells[8].Value.ToString().Equals(cbPessoas.Text))
                        {
                            row.Visible = true;
                            valorTotal += Convert.ToDecimal(row.Cells[6].Value.ToString());

                            if (DateTime.TryParse(row.Cells[7].Value?.ToString(), out cellDate))
                            {
                                if (!colorMap.ContainsKey(cellDate))
                                {
                                    Color pastelColor = Color.FromArgb(
                                        random.Next(200, 256), // Red
                                        random.Next(200, 256), // Green
                                        random.Next(200, 256)  // Blue
                                    );
                                    colorMap[cellDate] = pastelColor;
                                }
                                row.DefaultCellStyle.BackColor = colorMap[cellDate];
                            }
                        }
                    }
                }
                else if (exibeLinha)
                {
                    if (!check)
                    {
                        if (cbPessoas.Text == "(Todos)")
                        {
                            if (DateTime.TryParse(row.Cells[7].Value?.ToString(), out cellDate))
                            {
                                if (cellDate.Month == dataPickerStart.Value.Month && cellDate.Year == dataPickerStart.Value.Year)
                                {
                                    row.Visible = true;
                                    valorTotal += Convert.ToDecimal(row.Cells[6].Value.ToString());

                                    if (!colorMap.ContainsKey(cellDate))
                                    {
                                        Color pastelColor = Color.FromArgb(
                                            random.Next(200, 256), // Red
                                            random.Next(200, 256), // Green
                                            random.Next(200, 256)  // Blue
                                        );
                                        colorMap[cellDate] = pastelColor;
                                    }
                                    row.DefaultCellStyle.BackColor = colorMap[cellDate];
                                }
                                else
                                {
                                    row.Visible = false;
                                }
                            }
                            else
                            {
                                row.Visible = false;
                            }
                            if (row.Cells[10].Value.ToString() == "Pendente")
                            {
                                row.Cells[10].Style.ForeColor = Color.FromArgb(156, 0, 0);
                            }
                            else if (row.Cells[10].Value.ToString() == "Realizado")
                            {
                                row.Cells[10].Style.ForeColor = Color.FromArgb(0, 156, 0);
                            }
                            else
                            {
                                row.Cells[10].Style.ForeColor = Color.FromArgb(0, 0, 156);
                            }
                        }
                        else if (row.Cells[8].Value != null && row.Cells[8].Value.ToString().Equals(cbPessoas.Text))
                        {
                            if (DateTime.TryParse(row.Cells[7].Value?.ToString(), out cellDate))
                            {
                                if (cellDate.Month == dataPickerStart.Value.Month && cellDate.Year == dataPickerStart.Value.Year)
                                {
                                    row.Visible = true;
                                    valorTotal += Convert.ToDecimal(row.Cells[6].Value.ToString());

                                    if (!colorMap.ContainsKey(cellDate))
                                    {
                                        Color pastelColor = Color.FromArgb(
                                            random.Next(200, 256), // Red
                                            random.Next(200, 256), // Green
                                            random.Next(200, 256)  // Blue
                                        );
                                        colorMap[cellDate] = pastelColor;
                                    }
                                    row.DefaultCellStyle.BackColor = colorMap[cellDate];
                                }
                                else
                                {
                                    row.Visible = false;
                                }
                            }
                            else
                            {
                                row.Visible = false;
                            }
                            if (row.Cells[10].Value.ToString() == "Pendente")
                            {
                                row.Cells[10].Style.ForeColor = Color.FromArgb(156, 0, 0);
                            }
                            else if (row.Cells[10].Value.ToString() == "Realizado")
                            {
                                row.Cells[10].Style.ForeColor = Color.FromArgb(0, 156, 0);
                            }
                            else
                            {
                                row.Cells[10].Style.ForeColor = Color.FromArgb(0, 0, 156);
                            }
                        }
                    }
                    else // nao considera data
                    {
                        if (cbPessoas.Text == "(Todos)")
                        {
                            row.Visible = true;
                            valorTotal += Convert.ToDecimal(row.Cells[6].Value.ToString());

                            if (DateTime.TryParse(row.Cells[7].Value?.ToString(), out cellDate))
                            {
                                if (!colorMap.ContainsKey(cellDate))
                                {
                                    Color pastelColor = Color.FromArgb(
                                        random.Next(200, 256), // Red
                                        random.Next(200, 256), // Green
                                        random.Next(200, 256)  // Blue
                                    );
                                    colorMap[cellDate] = pastelColor;
                                }
                                row.DefaultCellStyle.BackColor = colorMap[cellDate];
                            }
                        }
                        else if (row.Cells[8].Value != null && row.Cells[8].Value.ToString().Equals(cbPessoas.Text))
                        {
                            row.Visible = true;
                            valorTotal += Convert.ToDecimal(row.Cells[6].Value.ToString());

                            if (DateTime.TryParse(row.Cells[7].Value?.ToString(), out cellDate))
                            {
                                if (!colorMap.ContainsKey(cellDate))
                                {
                                    Color pastelColor = Color.FromArgb(
                                        random.Next(200, 256), // Red
                                        random.Next(200, 256), // Green
                                        random.Next(200, 256)  // Blue
                                    );
                                    colorMap[cellDate] = pastelColor;
                                }
                                row.DefaultCellStyle.BackColor = colorMap[cellDate];
                            }
                        }
                    }
                }
                else
                {
                    row.Visible = false;
                }
                if (row.Cells[10].Value.ToString() == "Pendente")
                {
                    row.Cells[10].Style.ForeColor = Color.FromArgb(156, 0, 0);
                }
                else if (row.Cells[10].Value.ToString() == "Realizado")
                {
                    row.Cells[10].Style.ForeColor = Color.FromArgb(0, 156, 0);
                }
                else
                {
                    row.Cells[10].Style.ForeColor = Color.FromArgb(0, 0, 156);
                }
            }
            txtTotal.Text = "R$ " + valorTotal.ToString();
        }


        private void cbPagamento_SelectedIndexChanged(object sender, EventArgs e)
        {
            Pagamento();
            ExibirPessoa();

            ExibirPessoa();
            Pagamento();
            valorTotalDesconto();


            mesesComboBox.Visible = false;
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

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
            mesesComboBox.Visible = false;

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
                    string BuscaDes = row.Cells[4].Value.ToString().Normalize();
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

                    BuscaDes = row.Cells[4].Value.ToString().Normalize();
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
                ExibirDados();
                MessageBox.Show("Nenhum item encontrado.");
                return;
            }
            else
            {
                dataGridViewDados.ClearSelection();
                return;
            }*/
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
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

                mesesComboBox.Visible = false;

                int index = dataGridViewDados.SelectedRows[0].Index;
                var linhaSelecionada = dataGridViewDados.Rows[index];

                string id = linhaSelecionada.Cells[0].Value.ToString(); // Pega o ID

                var linhas = File.ReadAllLines(caminhoArquivoVendas).ToList();

                // Encontra a linha correspondente pelo ID
                int linhaParaDeletar = linhas.FindIndex(l => l.StartsWith(id + "*"));
                if (linhaParaDeletar >= 0)
                {
                    linhas.RemoveAt(linhaParaDeletar); // Remove o item correspondente ao ID
                    File.WriteAllLines(caminhoArquivoVendas, linhas);
                    MessageBox.Show("Dados deletados com sucesso!");
                    ExibirDados(); // Recarregar os dados no DataGridView
                }
                else
                {
                    MessageBox.Show("Erro ao encontrar o item para deletar.");
                }

                AddCliente();
                ExibirDados();
                Pagamento();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            /*int index = dataGridViewDados.SelectedRows[0].Index;
            var linhaSelecionada = dataGridViewDados.Rows[index];

            string id = linhaSelecionada.Cells[0].Value.ToString();
            string idVenda = linhaSelecionada.Cells[1].Value.ToString();
            string livroId = linhaSelecionada.Cells[2].Value.ToString();
            string categoria = linhaSelecionada.Cells[3].Value.ToString();
            string descricao = linhaSelecionada.Cells[4].Value.ToString();
            decimal qnt = decimal.Parse(linhaSelecionada.Cells[5].Value.ToString());
            decimal preco = decimal.Parse(linhaSelecionada.Cells[6].Value.ToString());
            string data = linhaSelecionada.Cells[7].Value.ToString();
            string nome_comprador = linhaSelecionada.Cells[8].Value.ToString();
            string tell = linhaSelecionada.Cells[9].Value.ToString();
            string pagamento = linhaSelecionada.Cells[10].Value.ToString();
            var linhas = File.ReadAllLines(caminhoArquivoVendas).ToList();

            // Encontrar a linha correspondente pelo ID
            int linhaParaAtualizar = linhas.FindIndex(l => l.StartsWith(id + "*"));

            if (linhaParaAtualizar >= 0)
            {
                // Atualizar a linha com os novos dados
                linhas[linhaParaAtualizar] = $"{id}*{livroId}*{categoria}*{descricao}*{qnt}*{preco}*{data}*{nome_comprador}*{tell}*{pagamento}";

                // Escrever as alterações no arquivo
                File.WriteAllLines(caminhoArquivoVendas, linhas);
                MessageBox.Show("Dados atualizados com sucesso!");
                AddCliente();
            }*/
            EditarMultiplasLinhas();
        }

        private void AplicarDesconto_Click(object sender, EventArgs e)
        {
            /*FormDesconto formDesconto = new FormDesconto();

            formDesconto.Show();*/
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnDevolver_Click(object sender, EventArgs e)
        {
            if (dataGridViewDados.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecione um item para devolver.");
                return;
            }

            int index = dataGridViewDados.SelectedRows[0].Index;
            var linhaSelecionada = dataGridViewDados.Rows[index];

            string id = linhaSelecionada.Cells[0].Value.ToString();
            string idv = linhaSelecionada.Cells[1].Value.ToString();
            string livroId = linhaSelecionada.Cells[2].Value.ToString();
            string categoria = linhaSelecionada.Cells[3].Value.ToString();
            string descricao = linhaSelecionada.Cells[4].Value.ToString();
            int qnt = int.Parse(linhaSelecionada.Cells[5].Value.ToString());
            decimal preco = decimal.Parse(linhaSelecionada.Cells[6].Value.ToString());
            string data = linhaSelecionada.Cells[7].Value.ToString();
            string nome_comprador = linhaSelecionada.Cells[8].Value.ToString();
            string tell = linhaSelecionada.Cells[9].Value.ToString();
            string pagamento = linhaSelecionada.Cells[10].Value.ToString();
            var linhas = File.ReadAllLines(caminhoArquivoVendas).ToList();

            int linhaParaAtualizar = linhas.FindIndex(l => l.StartsWith(id + "*" + idv + "*"));

            var linhasC = File.ReadAllLines(caminhoArquivoCliente).ToList();
            var linhasV = File.ReadAllLines(caminhoArquivoVendas).ToList();
            var linhasP = File.ReadAllLines(caminhoArquivo).ToList();



            if (linhaParaAtualizar >= 0 && pagamento != "Devolvido")
            {
                /*if (!(string.IsNullOrEmpty(nome_comprador)) && pagamento == "Realizado")
                {
                    DialogResult confirmResult = MessageBox.Show("Deseja devolver o valor em créditos do sistema?","", MessageBoxButtons.YesNo);
                   
                    if(confirmResult == DialogResult.Yes)
                    {

                        foreach (var linha in linhasC)
                        {
                            var dadosCliente = linha.Split('*');
                            if(dadosCliente.Length >= 6)
                            {
                                string idc = dadosCliente[0].Trim();
                                string cliente = dadosCliente[1].Trim();
                                string telefone = dadosCliente[2].Trim();
                                string valorDivida = dadosCliente[3].Trim();
                                string desconto = dadosCliente[4].Trim();
                                string credito = dadosCliente[5].Trim();

                                if (nome_comprador.Equals(cliente))
                                {
                                    int linhaParaAtualizarC = linhasC.FindIndex(l => l.StartsWith(idc + "*"));
                                    decimal cre = decimal.Parse(credito) + preco;
                                    linhasC[linhaParaAtualizarC] = $"{idc}*{cliente}*{telefone}*{valorDivida}*{desconto}*{cre.ToString()}";
                                    break;
                                }
                            }
                        }

                        File.WriteAllLines(caminhoArquivoCliente, linhasC);
                    }

                }*/

                foreach(var linha in linhasP)
                {
                    var dadosProduto = linha.Split('*');
                    if(dadosProduto.Length >= 9)
                    {
                        string idp = dadosProduto[0].Trim();
                        string idl = dadosProduto[1].Trim();
                        string cat = dadosProduto[2].Trim();
                        string desc = dadosProduto[3].Trim();
                        string qntp = dadosProduto[4].Trim();
                        string precop = dadosProduto[5].Trim();
                        string datap = dadosProduto[6].Trim();
                        string sit = dadosProduto[7].Trim();
                        string extra = dadosProduto[8].Trim();

                        if (idp.Equals(id))
                        {
                            int linhaParaAtualizarP = linhasP.FindIndex(l => l.StartsWith(idp + "*"));
                            int qntn = int.Parse(qntp) + qnt;
                            linhasP[linhaParaAtualizarP] = $"{idp}*{idl}*{cat}*{desc}*{qntn.ToString()}*{precop}*{datap}*{sit}*{extra}";
                            break;
                        }
                    }
                }
                File.WriteAllLines(caminhoArquivo, linhasP);

                pagamento = "Devolvido";

                // Atualizar a linha com os novos dados
                linhas[linhaParaAtualizar] = $"{id}*{idv}*{livroId}*{categoria}*{descricao}*{qnt}*{preco}*{data}*{nome_comprador}*{tell}*{pagamento}";

                // Escrever as alterações no arquivo
                File.WriteAllLines(caminhoArquivoVendas, linhas);
                MessageBox.Show("Dados atualizados com sucesso!");

                AddCliente();
                ExibirDados();
            }
            else
            {
                MessageBox.Show("Essa venda já foi devolvida");
            }
            Pagamento();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
           
            if (checkBox1.Checked)
            {
                dataPickerStart.Enabled = true;
            }
            else
            {
                dataPickerStart.Enabled = false;
            }
            ExibirPessoa();
            Pagamento();
            valorTotalDesconto();

            mesesComboBox.Visible = false;
        }

        private void mesesComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (mesesComboBox.Text == "Realizado")
            {
                GetSelectedRows("Realizado")
;            }
            if(mesesComboBox.Text == "Pendente")
            {
                GetSelectedRows("Pendente");
            }
        }

        void GetSelectedRows(string novoEstado)
        {
            Int32 selectedRowCount =
                dataGridViewDados.Rows.GetRowCount(DataGridViewElementStates.Selected);

            string input = InputBox.Show("forma de pagamento");
            if (selectedRowCount > 0)
            {
                System.Text.StringBuilder sb = new System.Text.StringBuilder();

                for (int i = 0; i < selectedRowCount; i++)
                {
            
                    dataGridViewDados.SelectedRows[i].Cells[10].Value = novoEstado;
                    dataGridViewDados.SelectedRows[i].Cells[4].Value = dataGridViewDados.SelectedRows[i].Cells[4].Value + input;
                }

                sb.Append("Total: " + selectedRowCount.ToString());
               // MessageBox.Show(sb.ToString(), "Selected Rows");
            }
        }

        void EditarMultiplasLinhas()
        {
            Int32 selectedRowCount =
                dataGridViewDados.Rows.GetRowCount(DataGridViewElementStates.Selected);
            if (selectedRowCount > 0)
            {
                System.Text.StringBuilder sb = new System.Text.StringBuilder();

                for (int i = 0; i < selectedRowCount; i++)
                {

                    string id = dataGridViewDados.SelectedRows[i].Cells[0].Value.ToString();
                    string idV = dataGridViewDados.SelectedRows[i].Cells[1].Value.ToString();
                    string livroId = dataGridViewDados.SelectedRows[i].Cells[2].Value.ToString();
                    string categoria = dataGridViewDados.SelectedRows[i].Cells[3].Value.ToString();
                    string descricao = dataGridViewDados.SelectedRows[i].Cells[4].Value.ToString();
                    decimal qnt = decimal.Parse(dataGridViewDados.SelectedRows[i].Cells[5].Value.ToString());
                    decimal preco = decimal.Parse(dataGridViewDados.SelectedRows[i].Cells[6].Value.ToString());
                    string data = dataGridViewDados.SelectedRows[i].Cells[7].Value.ToString();
                    string nome_comprador = dataGridViewDados.SelectedRows[i].Cells[8].Value.ToString();
                    string tell = dataGridViewDados.SelectedRows[i].Cells[9].Value.ToString();
                    string pagamento = dataGridViewDados.SelectedRows[i].Cells[10].Value.ToString();
                    var linhas = File.ReadAllLines(caminhoArquivoVendas).ToList();
                    // Encontrar a linha correspondente pelo ID
                    int linhaParaAtualizar = linhas.FindIndex(l => l.StartsWith(idV + "*"));

                    if (linhaParaAtualizar >= 0)
                    {
                        // Atualizar a linha com os novos dados
                        linhas[linhaParaAtualizar] = $"{id}*{idV}*{livroId}*{categoria}*{descricao}*{qnt}*{preco}*{data}*{nome_comprador}*{tell}*{pagamento}";

                        // Escrever as alterações no arquivo
                        File.WriteAllLines(caminhoArquivoVendas, linhas);
                        //MessageBox.Show("Dados atualizados com sucesso!");
                        AddCliente();
                    }
                }

                sb.Append("Total: " + selectedRowCount.ToString());
                //MessageBox.Show(sb.ToString(), "Selected Rows");
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            mesesComboBox.Visible = false;

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
                    string BuscaDes = row.Cells[4].Value.ToString().Normalize();
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

                    BuscaDes = row.Cells[4].Value.ToString().Normalize();
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

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            Microsoft.Office.Interop.Excel.Application excel = null;
            Microsoft.Office.Interop.Excel.Workbook workbook = null;
            Microsoft.Office.Interop.Excel.Worksheet sheet1 = null;
            var formProgresso = new FormVender();

            try
            {
                excel = new Microsoft.Office.Interop.Excel.Application();
                workbook = excel.Workbooks.Add(System.Reflection.Missing.Value);
                sheet1 = (Microsoft.Office.Interop.Excel.Worksheet)workbook.Sheets[1];

                Font headerFont = new Font("Arial", 10, FontStyle.Bold);
                sheet1.Cells.Font.Size = 10;
                int StartCol = 1;
                int StartRow = 1;
                int j = 0, i = 0;
                sheet1.PageSetup.Orientation = Microsoft.Office.Interop.Excel.XlPageOrientation.xlLandscape;

                formProgresso.Show();

                BackgroundWorker worker = new BackgroundWorker();
                worker.WorkerReportsProgress = true;
                worker.WorkerSupportsCancellation = true;

                worker.DoWork += (s, args) =>
                {
                    //Write Headers
                    for (j = 2; j < dataGridViewDados.Columns.Count; j++)
                    {
                        if (formProgresso.Cancelar)
                        {
                            args.Cancel = true;
                            return;
                        }

                        Microsoft.Office.Interop.Excel.Range myRange = (Microsoft.Office.Interop.Excel.Range)sheet1.Cells[StartRow, StartCol + j - 2];

                        if (dataGridViewDados.Columns[j].HeaderText == "Pag do livro")
                            myRange.Value2 = "Pag";
                        else if (dataGridViewDados.Columns[j].HeaderText == "Quantidade Vendida")
                            myRange.Value2 = "QTV";
                        else
                            myRange.Value2 = dataGridViewDados.Columns[j].HeaderText;

                        myRange.Columns.AutoFit();
                        myRange.Interior.Color = ColorTranslator.ToOle(Color.FromArgb(93, 173, 226));
                        myRange.Borders.Color = ColorTranslator.ToOle(Color.FromArgb(0, 0, 0));
                        myRange.Font.Bold = true;
                        worker.ReportProgress(0, $"Exportando cabeçalhos....");

                        sheet1.Cells[StartRow, j - 1].HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                    }

                    StartRow++;

                    //Write datagridview content
                    for (i = 0; i < dataGridViewDados.Rows.Count; i++)
                    {
                        if (formProgresso.Cancelar)
                        {
                            args.Cancel = true;
                            return;
                        }

                        sheet1.Columns.AutoFit();
                        for (j = 2; j < dataGridViewDados.Columns.Count; j++)
                        {
                            Microsoft.Office.Interop.Excel.Range myRange = (Microsoft.Office.Interop.Excel.Range)sheet1.Cells[StartRow + i, StartCol + j - 2];
                            if(j == 2)
                                myRange.NumberFormat = "@";

                            if(j == 3)
                            {
                                string str = dataGridViewDados[j, i].Value.ToString();
                                string str2;
                                if (str.Length >= 30)
                                {
                                    str2 = str.Remove(29);
                                    myRange.Value2 = str2 + "...";
                                }
                                else
                                {
                                    myRange.Value2 = str;
                                }
                            }
                            else
                            {
                                myRange.Value2 = dataGridViewDados[j, i].Value == null ? "" : dataGridViewDados[j, i].Value;
                            }

                            sheet1.Cells[StartRow + i, j - 1].HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            myRange.Borders.Color = ColorTranslator.ToOle(Color.FromArgb(0, 0, 0));

                            int progresso = (int)((double)i / dataGridViewDados.Rows.Count * 100);
                            worker.ReportProgress(progresso, $"Exportando linhas {i} de {dataGridViewDados.Rows.Count}");
                        }
                    }
                };

                worker.ProgressChanged += (s, args) =>
                {
                    formProgresso.AttBar(args.ProgressPercentage, (string)args.UserState);
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
                if(sheet1 != null)
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

        private void dataGridViewDados_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            // Verifica se a linha clicada é válida
            if (e.RowIndex >= 0)
            {
                mesesComboBox.Visible = true;
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Process.Start(new ProcessStartInfo("https://www.youtube.com/watch?v=HAImeHSBUfE&list=PLhEZRWtYRMyt4enwYFTX7io5NHKbluSaG")
            { UseShellExecute = true });
        }
    }

    //gpt apagart se der merda
    public class InputBox
    {
        public static string Show(string prompt, string title = "Input")
        {
            Form inputForm = new Form();
            Label label = new Label();
            //TextBox textBox = new TextBox();
            ComboBox comboBox = new ComboBox();
            Button confirmButton = new Button();
            Button cancelButton = new Button();

            // Configurações do form
            inputForm.Text = title;
            inputForm.FormBorderStyle = FormBorderStyle.FixedDialog;
            inputForm.StartPosition = FormStartPosition.CenterScreen;
            inputForm.ClientSize = new System.Drawing.Size(300, 120);
            inputForm.AcceptButton = confirmButton;

            // Configurações do Label
            label.Text = prompt;
            label.SetBounds(10, 10, 280, 20);

            // Configurações do TextBox
            //textBox.SetBounds(10, 40, 260, 20);
            comboBox.SetBounds(10, 40, 260, 20);
            comboBox.Items.Add("(PIX)");
            comboBox.Items.Add("(DINHEIRO)");
            comboBox.Items.Add("(CREDITO)");
            comboBox.Items.Add("(DEBITO)");
            comboBox.Items.Add("(TRANSFERÊNCIA BANCÁRIA)");
            // Configurações do Button Confirm
            confirmButton.Text = "OK";
            confirmButton.DialogResult = DialogResult.OK;
            confirmButton.SetBounds(180, 70, 75, 23);

            // Configurações do Button Cancel
            cancelButton.Text = "Cancelar";
            cancelButton.DialogResult = DialogResult.Cancel;
            cancelButton.SetBounds(100, 70, 75, 23);

            // Adiciona os controles no form
            inputForm.Controls.Add(label);
            //inputForm.Controls.Add(textBox);
            inputForm.Controls.Add(comboBox);
            inputForm.Controls.Add(confirmButton);
            inputForm.Controls.Add(cancelButton);
            comboBox.SelectedIndex = 0;
            // Exibe o form e retorna o texto
            DialogResult result = inputForm.ShowDialog();
            if (result == DialogResult.OK)
            {
                return comboBox.Text;
            }
            else
            {
                return null;
            }
        }
    }

}

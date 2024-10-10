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
        decimal valorTotal = 0;
        string caminhoArquivoVendas = "Vendas.txt";
        string caminhoArquivo = "dados.txt";
        DateTime data1;
        DateTime data2;
        public FormTabelaVenda()
        {
            InitializeComponent();
            DateTime data1 = new DateTime();
            data1 = dataPickerStart.Value;
       
            
            cbPessoas.Items.Add("(Todos)");
            cbPessoas.SelectedIndex = 0;
            ExibirDados();
        }

        private void dataGridViewDados_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

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
                    // Certifique-se de que há 4 campos (categoria, descrição, quantidade, preço) // agr to pegando o id junto já q ele tá iterável
                    if (dados.Length == 10)
                    {
                        string id = dados[0].Trim();
                        string idLivro = dados[1].Trim();
                        string categoria = dados[2].Trim();
                        string descricao = dados[3].Trim();
                        string qnt = dados[4].Trim();
                        string preco = dados[5].Trim();
                        string data = dados[6].Trim();
                        string nome = dados[7].Trim();
                        string telefone = dados[8].Trim();
                        string pagamento = dados[9].Trim();
                        // Adicionar os dados no DataGridView
                        dataGridViewDados.Rows.Add(id, idLivro, categoria, descricao, qnt, preco, data, nome, telefone, pagamento);
                        valorTotal += Convert.ToDecimal(preco);
                        foreach(var nomes in cbPessoas.Items)
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
                txtTotal.Text = valorTotal.ToString();
                dataGridViewDados.ClearSelection();
            }
            else
            {
                MessageBox.Show("Nenhum dado encontrado.");
            }
        }

        public void ExibirPessoa()
        {


            valorTotal = 0;
            dataGridViewDados.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            if (cbPessoas.Text == "(Todos)")
            {
                ExibirDados();
                foreach (DataGridViewRow row in dataGridViewDados.Rows)
                {


                    DateTime cellDate;
                    if (DateTime.TryParse(row.Cells[6].Value?.ToString(), out cellDate))
                    {
                        if (cellDate.Date == dataPickerStart.Value.Date)
                        {
                            row.Visible = true;
                            valorTotal += Convert.ToDecimal(row.Cells[5].Value.ToString());
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
            }
            else
            {
                foreach (DataGridViewRow row in dataGridViewDados.Rows)
                {

                    if (row.Cells[7].Value != null &&
    row.Cells[7].Value.ToString().Equals(cbPessoas.Text))
                    {
                        DateTime cellDate;
                        if (DateTime.TryParse(row.Cells[6].Value?.ToString(), out cellDate))
                        {
                            if (cellDate.Date == dataPickerStart.Value.Date)
                            {
                                row.Visible = true;
                                valorTotal += Convert.ToDecimal(row.Cells[5].Value.ToString());
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
                        row.Visible = false;
                    }



                }
            }
            txtTotal.Text = "R$ " + valorTotal.ToString();
           
        }
        private void FormTabelaVenda_Load(object sender, EventArgs e)
        {
            System.Drawing.Rectangle workingRectangle = Screen.PrimaryScreen.WorkingArea;
            this.Size = new System.Drawing.Size(Convert.ToInt32(0.5 * workingRectangle.Width),
                Convert.ToInt32(0.5 * workingRectangle.Height));

            this.Location = new System.Drawing.Point(10, 10);

        
            this.Width = 1280;
            this.Height = 720;



           

        }

        private void cbPessoas_SelectedIndexChanged(object sender, EventArgs e)
        {
            ExibirPessoa();
        }

     

        private void dataPickerStart_ValueChanged(object sender, EventArgs e)
        {
            ExibirPessoa();
        }

        private void cbPagamento_SelectedIndexChanged(object sender, EventArgs e)
        {
            string value = cbPagamento.Text;

            if (value == "realizado")
            {

            }
        }
    }
}

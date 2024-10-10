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
                    // Certifique-se de que há 10 campos (categoria, descrição, quantidade, preço) // agr to pegando o id junto já q ele tá iterável
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
            Pagamento();
        }



        private void dataPickerStart_ValueChanged(object sender, EventArgs e)
        {
            ExibirPessoa();
            Pagamento();
        }

        public void Pagamento()
        {
            valorTotal = 0;


            foreach (DataGridViewRow row in dataGridViewDados.Rows)
            {
                string value = cbPagamento.Text;
                string pagamento = row.Cells[9].Value?.ToString();
                string nome = row.Cells[7].Value?.ToString();
                bool exibeLinha = (pagamento == value) && (cbPessoas.Text == "(Todos)" || cbPessoas.Text == nome);
                if (exibeLinha)
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
            txtTotal.Text = valorTotal.ToString();
        }
        private void cbPagamento_SelectedIndexChanged(object sender, EventArgs e)
        {
            Pagamento();
            ExibirPessoa();

            ExibirPessoa();
            Pagamento();

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

                    BuscaDes = row.Cells[3].Value.ToString().Normalize();
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
            }
        }
    }
}

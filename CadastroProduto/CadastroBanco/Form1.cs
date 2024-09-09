using System;
using System.Collections.Generic;
using System.Windows.Forms;
using static CadastroBanco.Form1;

namespace CadastroBanco
{
    public partial class Form1 : RoundRectForm
    {
        // Lista para armazenar os dados localmente
        private List<Produto> produtos = new List<Produto>();
        public int contador = 0;
        public Form1()
        {
            InitializeComponent();
            textBox1.Text = "0";
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click_1(object sender, EventArgs e)
        {

        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        // Classe para representar uma Produto
        public class Produto
        {
            public int Id { get; set; }
            public string TipoProd { get; set; }
            public string Marca { get; set; }
            public double ValorCompra { get; set; }
            public double ValorVenda { get; set; }
            public double MargemLucro { get; set; }
            public string DataVal { get; set; }
            public bool Sim { get; set; }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        // Botão para criar/adicionar uma produto
        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = Convert.ToString(Convert.ToInt32(textBox1.Text) + 1); 
            Produto novoProduto = new Produto()
            {
                Id = Convert.ToInt32(textBox1.Text),
                TipoProd = textBox2.Text,
                Marca = textBox3.Text,
                ValorCompra = Convert.ToDouble(textBox4.Text),
                ValorVenda = Convert.ToDouble(textBox8.Text),
                MargemLucro = Convert.ToDouble(textBox6.Text),
                DataVal = textBox5.Text,
                Sim = checkBox1.Checked
            };

            Produto produtoExistente = produtos.Find(p => p.Id == Convert.ToInt32(textBox1.Text));

            if (produtoExistente != null)
            {
                MessageBox.Show("Id do produto já existente");
            }
            else
            {
                produtos.Add(novoProduto);
                MessageBox.Show("Produto cadastrado com sucesso!!!");
            }
            Consultar();
        }

        // Botão para ler/exibir todos os produtos
        private void button2_Click(object sender, EventArgs e)
        {
            Consultar();
        }

        void Consultar()
        {
            listBox1.Items.Clear();

            if (produtos.Count > 0)
            {
                foreach (var produto in produtos)
                {
                    listBox1.Items.Add("Código do Produto: " + produto.Id);
                    listBox1.Items.Add("Tipo do Produto: " + produto.TipoProd);
                    listBox1.Items.Add("Marca: " + produto.Marca);
                    listBox1.Items.Add("Valor de Aquisição: " + produto.ValorCompra);
                    listBox1.Items.Add("Valor de Venda: " + produto.ValorVenda);
                    listBox1.Items.Add("Margem de Lucro: " + produto.MargemLucro);
                    listBox1.Items.Add("Comercializável: " + (produto.Sim ? "Sim" : "Não"));
                    listBox1.Items.Add("Data de validade: " + produto.DataVal);
                    listBox1.Items.Add("------------------------------------------------------");
                }
            }
            else
            {
                MessageBox.Show("Não há registros");
            }
        }

        // Botão para atualizar um produto
        private void button3_Click(object sender, EventArgs e)
        {
            //int idProduto = Convert.ToInt32(textBox1.Text);
            int idProduto = 0;
            foreach (var item in listBox1.SelectedItems)
            {
                string s = item.ToString();
                string[] sub = s.Split(':');
                idProduto = Convert.ToInt32(sub[1]);
                //textBox1.Text = item.ToString();

                //idProduto = Convert.ToInt32(sub);
            }
            // Remover um produto da lista pelo número

            // Encontrar o produto pelo id
            Produto produtoParaAtualizar = produtos.Find(p => p.Id == idProduto);

            if (produtoParaAtualizar != null)
            {
                produtoParaAtualizar.TipoProd = textBox2.Text;
                produtoParaAtualizar.Marca = textBox3.Text;
                produtoParaAtualizar.MargemLucro = Convert.ToInt32(textBox6.Text);
                produtoParaAtualizar.ValorCompra = Convert.ToInt32(textBox4.Text);
                produtoParaAtualizar.ValorVenda = Convert.ToInt32(textBox8.Text);
                produtoParaAtualizar.DataVal = textBox5.Text;
                produtoParaAtualizar.Sim = checkBox1.Checked;
                MessageBox.Show("Produto atualizado com sucesso!");
            }
            else
            {
                MessageBox.Show("Produto não encontrada.");
            }

             Consultar();
        }

        // Botão para deletar um produto
        private void button4_Click(object sender, EventArgs e)
        {
            //int idProduto = Convert.ToInt32(textBox1.Text);
            int idProduto = 0;
            foreach (var item in listBox1.SelectedItems)
            {
                string s = item.ToString();
                string[] sub = s.Split(':');
                idProduto = Convert.ToInt32(sub[1]);
                //textBox1.Text = item.ToString();

                //idProduto = Convert.ToInt32(sub);
            }
            // Remover um produto da lista pelo número
            Produto produtoParaRemover = produtos.Find(p => p.Id == idProduto);

            if (produtoParaRemover != null)
            {
                produtos.Remove(produtoParaRemover);
                MessageBox.Show("Produto removida com sucesso!");
            }
            else
            {
                MessageBox.Show("Não existe");
            }
            Consultar();
        }

        // Botão para limpar os campos de texto
        private void button5_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
            checkBox1.Checked = false;
            checkBox2.Checked = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
           
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            
        }

        private void pictureBox7_Click_1(object sender, EventArgs e)
        {
            string tipoProd = textBox7.Text;
            string marca = textBox7.Text;
            List<Produto> produtosB = new List<Produto>();
            produtosB = produtos.FindAll(p => p.TipoProd == tipoProd || p.Marca == marca);
           //Produto produtoParaAchar = produtos.Find(p => p.TipoProd == tipoProd || p.Marca == marca);
            if (produtosB != null)
            {
                listBox1.Items.Clear();
                foreach (var produto in produtosB)
                {
                    listBox1.Items.Add("Código do Produto: " + produto.Id);
                    listBox1.Items.Add("Tipo do Produto: " + produto.TipoProd);
                    listBox1.Items.Add("Marca: " + produto.Marca);
                    listBox1.Items.Add("Valor de Aquisição: " + produto.ValorCompra);
                    listBox1.Items.Add("Valor de Venda: " + produto.ValorVenda);
                    listBox1.Items.Add("Margem de Lucro: " + produto.MargemLucro);
                    listBox1.Items.Add("Comercializável: " + (produto.Sim ? "Sim" : "Não"));
                    listBox1.Items.Add("Data de validade: " + produto.DataVal);
                    listBox1.Items.Add("------------------------------------------------------");
                }
            }
            else
            {
                MessageBox.Show("Não há registros");
            }
        }

        private void checkBox1_CheckedChanged_1(object sender, EventArgs e)
        { // tesxte 
            if (checkBox1.Checked)
            {
                checkBox2.Checked = false;
            }
        }
            
        private void checkBox2_CheckedChanged_1(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                checkBox1.Checked = false;
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CadastroBanco
{
    public partial class Form1 : Form
    {
        // Lista para armazenar os dados localmente
        private List<Conta> contas = new List<Conta>();

        public Form1()
        {
            InitializeComponent();
        }

        // Classe para representar uma Conta
        public class Conta
        {
            public string Numero { get; set; }
            public string Titular { get; set; }
            public string Saldo { get; set; }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        // Botão para criar/adicionar uma conta
        private void button1_Click(object sender, EventArgs e)
        {
            Conta novaConta = new Conta()
            {
                Numero = textBox1.Text,
                Titular = textBox2.Text,
                Saldo = textBox3.Text
            };

            contas.Add(novaConta);
            MessageBox.Show("Usuário cadastrado com sucesso!!!");
        }

        // Botão para ler/exibir todas as contas
        private void button2_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();

            if (contas.Count > 0)
            {
                foreach (var conta in contas)
                {
                    listBox1.Items.Add("Numero Conta: " + conta.Numero);
                    listBox1.Items.Add("Titular da Conta: " + conta.Titular);
                    listBox1.Items.Add("Saldo da Conta: " + conta.Saldo);
                    listBox1.Items.Add("----------------------------");
                }
            }
            else
            {
                MessageBox.Show("Não há registros");
            }
        }

        // Botão para atualizar uma conta
        private void button3_Click(object sender, EventArgs e)
        {
            string numeroConta = textBox1.Text;

            // Encontrar a conta pelo número
            Conta contaParaAtualizar = contas.Find(c => c.Numero == numeroConta);

            if (contaParaAtualizar != null)
            {
                contaParaAtualizar.Titular = textBox2.Text;
                contaParaAtualizar.Saldo = textBox3.Text;
                MessageBox.Show("Usuário atualizado com sucesso!");
            }
            else
            {
                MessageBox.Show("Conta não encontrada.");
            }
        }

        // Botão para deletar uma conta
        private void button4_Click(object sender, EventArgs e)
        {
            string numeroConta = textBox1.Text;

            // Remover a conta da lista pelo número
            Conta contaParaRemover = contas.Find(c => c.Numero == numeroConta);

            if (contaParaRemover != null)
            {
                contas.Remove(contaParaRemover);
                MessageBox.Show("Conta removida com sucesso!");
            }
            else
            {
                MessageBox.Show("Conta não encontrada.");
            }
        }

        // Botão para limpar os campos de texto
        private void button5_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
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
    }
}
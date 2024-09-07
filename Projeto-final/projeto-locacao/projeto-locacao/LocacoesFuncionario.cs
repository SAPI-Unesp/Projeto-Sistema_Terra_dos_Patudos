using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace projeto_locacao
{
    public partial class LocacoesFuncionario : Form
    {
        public LocacoesFuncionario()
        {
            InitializeComponent();
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            MenuPrincipalFuncionario m1 = new MenuPrincipalFuncionario();
            m1.Show();
            this.Hide();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        public void AtualizarAtraso()
        {
            string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=livraria;";
            string query = "update locacao set atrasado = 0 where data_fim > now()";
            MySqlConnection databaseConnection = new MySqlConnection(connectionString);
            MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);

            commandDatabase.CommandTimeout = 60;

            MySqlDataReader reader;

            databaseConnection.Open();

            reader = commandDatabase.ExecuteReader();

            databaseConnection.Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            ProcurarLocacao p1 = new ProcurarLocacao();
            ProcurarLocacao.IdLocacao = IdLocacao.Text;
            p1.Show();
            this.Hide();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Certeza c1 = new Certeza();
            c1.Show();
            this.Hide(); //"update locacao set data_fim = date_add(data_fim, INTERVAL 1 WEEK) where fk_idCliente = " + Form1.IdCliente

            string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=livraria;";
            string query = "update locacao set data_fim = date_add(data_fim, INTERVAL 1 WEEK) where idLocacao = " + IdLocacao.Text;
            MySqlConnection databaseConnection = new MySqlConnection(connectionString);
            MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);

            commandDatabase.CommandTimeout = 60;

            MySqlDataReader reader;

            databaseConnection.Open();

            reader = commandDatabase.ExecuteReader();

            databaseConnection.Close();

            AtualizarAtraso();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            CadastrarLocacao c1 = new CadastrarLocacao();
            c1.Show();
            this.Hide();
        }
        public void gerarLocacoesAtivas()
        {
            string connectionString = "datasource=localhost;port=3306;username=root;password=;database=livraria;";


            string query = "SELECT * FROM locacao where atrasado = 0 and terminado = 0" + Login.IdCliente;


            MySqlConnection databaseConnection = new MySqlConnection(connectionString);

            MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);

            commandDatabase.CommandTimeout = 60;


            MySqlDataReader reader;

            databaseConnection.Open();


            reader = commandDatabase.ExecuteReader();


            if (reader.HasRows)
            {

                while (reader.Read())
                {


                    string[] row = { reader.GetString(0), reader.GetString(1), reader.GetString(2),
                    reader.GetString(3), reader.GetString(4), reader.GetString(5),
                    reader.GetString(6), reader.GetString(7), reader.GetString(8)};

                    listBox1.Items.Add("----------------------------");
                    listBox1.Items.Add(" ");
                    listBox1.Items.Add("Id Locação: " + row[0]);

                    listBox1.Items.Add("Data de Início: " + row[1]);

                    listBox1.Items.Add("Data de Fim: " + row[2]);
                    listBox1.Items.Add("Atrasado: " + row[3]);

                    listBox1.Items.Add("Taxa: " + row[4]);

                    listBox1.Items.Add("Id Cliente: " + row[5]);
                    listBox1.Items.Add("Id Funcionario: " + row[6]);

                    listBox1.Items.Add("Id Livro: " + row[7]);

                    listBox1.Items.Add("Terminado: " + row[8]);
                    listBox1.Items.Add(" ");

                }
            }
        }
        private void LocacoesFuncionario_Load(object sender, EventArgs e)
        {
            gerarLocacoesAtivas();
            string connectionString = "datasource=localhost;port=3306;username=root;password=;database=livraria;";


            string query = "SELECT * FROM locacao where atrasado = 1 and terminado = 0";


            MySqlConnection databaseConnection = new MySqlConnection(connectionString);

            MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);

            commandDatabase.CommandTimeout = 60;


            MySqlDataReader reader;

            databaseConnection.Open();


            reader = commandDatabase.ExecuteReader();


            if (reader.HasRows)
            {

                while (reader.Read())
                {


                    string[] row = { reader.GetString(0), reader.GetString(1), reader.GetString(2),
                reader.GetString(3), reader.GetString(4), reader.GetString(5),
                reader.GetString(6), reader.GetString(7), reader.GetString(8), reader.GetString(9)};

                    listBox2.Items.Add("----------------------------");
                    listBox2.Items.Add(" ");
                    listBox2.Items.Add("Id Locação: " + row[0]);

                    listBox2.Items.Add("Data de Início: " + row[1]);

                    listBox2.Items.Add("Data de Fim: " + row[2]);
                    listBox2.Items.Add("Atrasado: " + row[3]);

                    listBox2.Items.Add("Taxa: " + row[4]);

                    listBox2.Items.Add("Id Cliente: " + row[5]);
                    listBox2.Items.Add("Id Funcionario: " + row[6]);

                    listBox2.Items.Add("Id Livro: " + row[7]);

                    listBox2.Items.Add("Terminado: " + row[8]);
                    listBox2.Items.Add(" ");

                }

            }
        }
    }
}

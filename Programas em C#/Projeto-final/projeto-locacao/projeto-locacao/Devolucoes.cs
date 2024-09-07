using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace projeto_locacao
{
    public partial class Devolucoes : Form
    {
        public Devolucoes()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
;
        }

        private void button2_Click(object sender, EventArgs e)
        {

            // julgar se é funcionario ou não
            if (MenuPrincipalFuncionario.FuncionarioB)
            {
                MenuPrincipalFuncionario m1 = new MenuPrincipalFuncionario();
                m1.Show();
                this.Hide();
            }
            else
            {
                MenuPrincipalCliente m1 = new MenuPrincipalCliente();
                m1.Show();
                this.Hide();
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
         
        }

        private void Devolucoes_Load(object sender, EventArgs e)
        {
            string connectionString = "datasource=localhost;port=3306;username=root;password=;database=livraria;";

            string query = "SELECT * FROM devolucao";

            if (MenuPrincipalCliente.ClienteB)
            {
                query = "SELECT * FROM devolucao, locacao where devolucao.idLocacao = locacao.idLocacao and locacao.fk_idCliente = " + Login.IdCliente;
            }

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


                    string[] row = { reader.GetString(0), reader.GetString(1) };

                    listBox1.Items.Add("----------------------------");
                    listBox1.Items.Add(" ");
                    listBox1.Items.Add("Id Devolução: " + row[1]);
                    listBox1.Items.Add("Data de Fim: " + row[0]);
                }

            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            string connectionString = "datasource=localhost;port=3306;username=root;password=;database=livraria;";

            listBox1.Items.Clear();

            if (Ano.Text == "Ano") Ano.Text = "____";
            if (Mes.Text == "Mês") Mes.Text = "__";
            if (Dia.Text == "Dia") Dia.Text = "__";
            string query = "SELECT * FROM devolucao where data_fim like '" + Ano.Text + "-" + Mes.Text + "-" + Dia.Text + "' order by data_fim asc";


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


                    string[] row = { reader.GetString(0), reader.GetString(1) };

                    listBox1.Items.Add("----------------------------");
                    listBox1.Items.Add(" ");
                    listBox1.Items.Add("Id Devolução: " + row[1]);
                    listBox1.Items.Add("Data de Fim: " + row[0]);
                    listBox1.Items.Add(" ");

                }
            }
        }
    }
}

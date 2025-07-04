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
    public partial class Relatorio : Form
    {
        public Relatorio()
        {
            InitializeComponent();
        }

        private void Relatório_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            //ordernar por data_início

            string connectionString = "datasource=localhost;port=3306;username=root;password=;database=livraria;";

            listBox1.Items.Clear();

            if (Ano.Text == "Ano") Ano.Text = "____";
            if (Mes.Text == "Mês") Mes.Text = "__";
            if (Dia.Text == "Dia") Dia.Text = "__";
            string query = "SELECT * FROM locacao where data_inicio like '"+Ano.Text+"-"+Mes.Text+"-"+Dia.Text+"' order by data_inicio asc";


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

        private void button2_Click(object sender, EventArgs e)
        {
            MenuPrincipalFuncionario m1 = new MenuPrincipalFuncionario();
            m1.Show();
            this.Hide();
        }
    }
}

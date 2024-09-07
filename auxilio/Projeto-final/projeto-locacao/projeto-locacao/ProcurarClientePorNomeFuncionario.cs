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
    public partial class ProcurarClientePorNomeFuncionario : Form
    {
        public static string SortaName { get; set; }
        public ProcurarClientePorNomeFuncionario()
        {
            InitializeComponent();
        }

        private void ProcurarClientePorNomeFuncionario_Load(object sender, EventArgs e)
        {
            string connectionString = "datasource=localhost;port=3306;username=root;password=;database=livraria;";

            listBox1.Items.Clear();

            string query = "SELECT * FROM cliente where nome like '%" + SortaName + "%'";


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


                    string[] row = { reader.GetString(0), reader.GetString(1), reader.GetString(2), reader.GetString(3),
                    reader.GetString(4), reader.GetString(5), reader.GetString(6), reader.GetString(7),
                    reader.GetString(8), reader.GetString(9)};

                    listBox1.Items.Add("----------------------------");
                    listBox1.Items.Add(" ");
                    listBox1.Items.Add("Id: " + row[0]);
                    listBox1.Items.Add("Nome: " + row[1]);
                    listBox1.Items.Add("Email: " + row[2]);
                    listBox1.Items.Add("Senha: " + row[3]);
                    listBox1.Items.Add("Cpf: " + row[4]);
                    listBox1.Items.Add("Cep: " + row[5]);
                    listBox1.Items.Add("Numero da Casa: " + row[6]);
                    listBox1.Items.Add("Complemento: " + row[7]);
                    listBox1.Items.Add("Apelido: " + row[8]);
                    listBox1.Items.Add("Status: " + row[9]);
                    listBox1.Items.Add(" ");

                }

            }

            else
            {

                MessageBox.Show("Não há registros");

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ProcurarClienteFuncionario p1 = new ProcurarClienteFuncionario();
            p1.Show();
            this.Hide();
        }
    }
}

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
    public partial class ProcurarLivroPorNome : Form
    {
        public static string SortaName { get; set; }
        public ProcurarLivroPorNome()
        {
            InitializeComponent();
        }

        private void ProcurarLivroPorNome_Load(object sender, EventArgs e)
        {
            string connectionString = "datasource=localhost;port=3306;username=root;password=;database=livraria;";

            listBox1.Items.Clear();

            string query = "SELECT idLivro, titulo, autor, valor_locacao FROM livro where titulo like '%" +SortaName+ "%'";


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


                    string[] row = { reader.GetString(0), reader.GetString(1), reader.GetString(2), reader.GetString(3) };

                    listBox1.Items.Add("----------------------------");
                    listBox1.Items.Add(" ");
                    listBox1.Items.Add("Id: " + row[0]);

                    listBox1.Items.Add("Nome: " + row[1]);

                    listBox1.Items.Add("Autor: " + row[2]);
                    listBox1.Items.Add("Preço: " + row[3]);
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
            if (MenuPrincipalCliente.ClienteB)
            {
                MenuPrincipalCliente m1 = new MenuPrincipalCliente();
                m1.Show();
                this.Hide();
            }
            if (MenuPrincipalFuncionario.FuncionarioB)
            {
                MenuPrincipalFuncionario m1 = new MenuPrincipalFuncionario();
                m1.Show();
                this.Hide();
            }
        }
    }
}

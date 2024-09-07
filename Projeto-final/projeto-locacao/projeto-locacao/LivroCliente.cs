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
    public partial class LivroCliente : Form
    {
        public LivroCliente()
        {
            InitializeComponent();
        }
        /* NO METODO LOAD


        */
        /* NO BOTÃO DE PROCURAR POR DATA

        MAIS VELHO:

  

        MAIS NOVO: (TROCAR POR ---LANÇAMENTOS---)




        */
        private void button3_Click(object sender, EventArgs e)
        {
            MenuPrincipalCliente m1 = new MenuPrincipalCliente();
            m1.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ProcurarLivroPorNome.SortaName = Nome.Text;
            ProcurarLivroPorNome l1 = new ProcurarLivroPorNome();
            l1.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=livraria;";

            string query = "SELECT * FROM Livro where idLivro = '" + IdLivro.Text + "' and status = 'disponivel'";

            MySqlConnection databaseConnection = new MySqlConnection(connectionString);
            MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);

            commandDatabase.CommandTimeout = 60;

            MySqlDataReader reader;

            try
            {
                databaseConnection.Open();

                reader = commandDatabase.ExecuteReader();

                if (reader.Read())
                {
                    InformacoesLivro.IdLivro = Convert.ToInt32(IdLivro.Text);

                    InformacoesLivro f1 = new InformacoesLivro();
                    f1.Show();
                    this.Hide();
                }
                databaseConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Livro Não Encontrado");
            }
        }

        private void LivroCliente_Load(object sender, EventArgs e)
        {
            string connectionString = "datasource=localhost;port=3306;username=root;password=;database=livraria;";


            string query = "SELECT idLivro, titulo, autor, data_chegada FROM livro where status = 'disponivel'";


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


                    string[] row = { reader.GetString(0), reader.GetString(1), reader.GetString(2)};

                    listBox1.Items.Add("----------------------------");
                    listBox1.Items.Add(" ");
                    listBox1.Items.Add("Id: " + row[0]);

                    listBox1.Items.Add("Nome: " + row[1]);

                    listBox1.Items.Add("Autor: " + row[2]);
                    listBox1.Items.Add(" ");

                }

            }

                else
                {

                    MessageBox.Show("Não há registros");

                }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear(); // -------

            string connectionString = "datasource=localhost;port=3306;username=root;password=;database=livraria;";

            string query;
            string ordem = "";
            if (comboBox1.Text == "Mais Velhos") { ordem = "order by data_chegada asc"; }
            if (comboBox1.Text == "Mais Novos") { ordem = "order by data_chegada desc"; }
            query = "SELECT idLivro, titulo, autor, data_chegada FROM livro where status = 'disponivel'" +ordem;


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


                    string[] row = { reader.GetString(0), reader.GetString(1), reader.GetString(2) };

                    listBox1.Items.Add("----------------------------");
                    listBox1.Items.Add(" ");
                    listBox1.Items.Add("Id: " + row[0]);

                    listBox1.Items.Add("Nome: " + row[1]);

                    listBox1.Items.Add("Autor: " + row[2]);
                    listBox1.Items.Add(" ");

                }

            }

            else
            {

                listBox1.Items.Clear(); // -------
                listBox1.Items.Add("Não há livros disponíveis");
            }
        }
    }
}

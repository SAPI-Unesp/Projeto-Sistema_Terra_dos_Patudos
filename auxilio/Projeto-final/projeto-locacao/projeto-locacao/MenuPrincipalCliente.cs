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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace projeto_locacao
{
    public partial class MenuPrincipalCliente : Form
    {
	    public static bool ClienteB{get;set;}

        public void gerarAtrasadas()
        {
            string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=livraria;";

            string query = "SELECT count(*) FROM locacao where fk_idCliente = " + Login.IdCliente + " AND terminado = 0 AND atrasado = 1";

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
                    string[] row = { reader.GetString(0) };
                    label3.Text = row[0];
                }

            }

            databaseConnection.Close();
        }
        public void gerarCategorias()
        {
            string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=livraria;";

            string query = "SELECT class_nome FROM classificacao";

            MySqlConnection databaseConnection = new MySqlConnection(connectionString);
            MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);

            commandDatabase.CommandTimeout = 60;

            MySqlDataReader reader;

            try
            {
                databaseConnection.Open();

                reader = commandDatabase.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {

                        string[] row = { reader.GetString(0)};
                        comboBox1.Items.Add(row[0]);
                    }
                }
                databaseConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public MenuPrincipalCliente()
        {
            InitializeComponent();
        }

        /* NO MÉTODO LOAD DA TELA


        */
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            EditarPerfilCliente.IdClienteC = Convert.ToString(Login.IdCliente);
            EditarPerfilCliente ed1 = new EditarPerfilCliente();
            this.Hide();
            ed1.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            LocacoesCliente l1 = new LocacoesCliente();
            this.Hide();
            l1.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Devolucoes d1 = new Devolucoes();
            this.Hide();
            d1.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            LivroCliente l1 = new LivroCliente();
            l1.Show();
            this.Hide();
        }

        private void MenuPrincipalCliente_Load(object sender, EventArgs e)
        {
            Cliente Cliente = new Cliente();
            ClienteB = true;

            string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=livraria;";

            string query = "SELECT * FROM Cliente where idCliente = " + Login.IdCliente;

            MySqlConnection databaseConnection = new MySqlConnection(connectionString);
            MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);

            commandDatabase.CommandTimeout = 60;

            MySqlDataReader reader;

            try
            {
                databaseConnection.Open();

                reader = commandDatabase.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {

                        string[] row = { reader.GetString(0), reader.GetString(1), 
                            reader.GetString(2), reader.GetString(3), reader.GetString(4), 
                            reader.GetString(5), reader.GetString(6), reader.GetString(7),
                        reader.GetString(8), reader.GetString(9)};
                        Cliente.IdCliente = Convert.ToInt32(row[0]);
                        Cliente.Nome = row[1];
                        Cliente.Email = row[2];
                        Cliente.Senha = row[3];
                        Cliente.Cpf = row[4];
                        Cliente.Cep = row[5];
                        Cliente.NumeroCasa = row[6];
                        Cliente.Complemento = row[7];
                        Cliente.Apelido = row[8];
                        Cliente.Status = row[9];

                        gerarCategorias();
                        gerarAtrasadas();
                        Olaapelido.Text = "Olá, " + Cliente.Apelido;
                    }
                }
                databaseConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=livraria;";

            string query = "SELECT idLivro, titulo, autor FROM livro where status = 'disponivel'";

            if (comboBox1.Text != "categoria")
            {
                query = "SELECT livro.idLivro, livro.titulo, livro.autor FROM livro " +
                    "join classifLivro on classifLivro.fk_idLivro = livro.idLivro " +
                    "join classificacao on classifLivro.fk_class_id = classificacao.class_id " +
                    "where classificacao.class_nome = '" + comboBox1.Text + "'";
            }

            MySqlConnection databaseConnection = new MySqlConnection(connectionString);
            MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);

            commandDatabase.CommandTimeout = 60;

            MySqlDataReader reader;

            try
            {
                databaseConnection.Open();

                reader = commandDatabase.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        string[] row = { reader.GetString(0), reader.GetString(1), reader.GetString(2) };
                        listBox1.Items.Add("Código = " + row[0]);
                        listBox1.Items.Add("Nome = " + row[1]);
                        listBox1.Items.Add("Autor = " + row[2]);
                        listBox1.Items.Add(" ");
                        listBox1.Items.Add("-----------------------");

                    }
                }
                databaseConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Login l1 = new Login();
            l1.Show();
            this.Hide();
        }
    }
}

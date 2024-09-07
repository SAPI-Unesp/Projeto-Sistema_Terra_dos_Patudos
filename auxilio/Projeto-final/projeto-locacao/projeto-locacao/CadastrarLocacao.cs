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
    public partial class CadastrarLocacao : Form
    {
        public CadastrarLocacao()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        public void MudarEstadoLivro()
        {
            string connectionString = "datasource=localhost;port=3306;username=root;password=;database=livraria;";

            string query = "update livro set status = 'locado' where idLivro = " + IdLivro.Text;


            MySqlConnection databaseConnection = new MySqlConnection(connectionString);

            MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);

            commandDatabase.CommandTimeout = 60;


            MySqlDataReader reader;

            try
            {
                databaseConnection.Open();

                reader = commandDatabase.ExecuteReader();

                databaseConnection.Close();
                MessageBox.Show("Sucesso");

                Funcionario f1 = new Funcionario();
                f1.ChamarMenuPrincipal();
                this.Hide();
            }
            catch (Exception ex)
            {

                MessageBox.Show("Algo deu errado durante a atualização dos dados, certifique-se que estão corretos");
            }
        }
        public void SalvarNovaLocacao()
        {
            string connectionString = "datasource=localhost;port=3306;username=root;password=;database=livraria;";

            string query = "INSERT INTO Locacao values (NULL, now(), date_add(now(), INTERVAL 1 WEEK),0,0, "+IdCliente.Text+ ", "+IdFuncionario.Text+", "+IdLivro.Text+", 0, 0)";


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

                }

            }

            MudarEstadoLivro();
        }
        public void ProcurarErro()
        {
            string connectionString = "datasource=localhost;port=3306;username=root;password=;database=livraria;";


            string query = "SELECT * From locacao where fk_idLivro = " + IdLivro.Text+" and terminado = 0";


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


                    MessageBox.Show("Não é possível alocar um livro alocado");
                }

            } else
            {
                SalvarNovaLocacao();
            }
        }
        public void GerarDatas()
        {
            string connectionString = "datasource=localhost;port=3306;username=root;password=;database=livraria;";


            string query = "SELECT now(), date_add(now(), INTERVAL 1 WEEK)";


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
                    
                    Data_inicio.Text = row[0];
                    Data_fim.Text = row[1];
                }

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string connectionString = "datasource=localhost;port=3306;username=root;password=;database=livraria;";


            string query = "SELECT valor_locacao FROM livro where idLivro = " + IdLivro.Text;


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


                    string[] row = { reader.GetString(0)};
                    IdFuncionario.Text = Convert.ToString(Login.IdFuncionario);
                    
                    Preco.Text = Convert.ToString(row[0]);

                }
            }
        }

        private void CadastarLocacao_Load(object sender, EventArgs e)
        {
            GerarDatas();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ProcurarErro();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Funcionario f1 = new Funcionario();
            f1.ChamarMenuPrincipal();
            this.Hide();
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace projeto_locacao
{
    public partial class Login : Form
    {
        public static int IdFuncionario {get; set;}
	    public static int IdCliente {get; set;}
	    public static int IdAdm {get; set;}
       
        public void AtualizarRetiradosRetornados()
        {
            string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=livraria;";

            string query = "DELETE FROM livro WHERE status = 'disponivel'";
            MySqlConnection databaseConnection = new MySqlConnection(connectionString);
            MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);

            commandDatabase.CommandTimeout = 60;

            MySqlDataReader reader;

            databaseConnection.Open();

            reader = commandDatabase.ExecuteReader();

            databaseConnection.Close();
        }
        public void AtualizarChegadas()
        {
            string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=livraria;";

            string query = "update locacao inner join livro on livro.idLivro = locacao.fk_idLivro set terminado = 1 where livro.status = 'disponivel'";
            MySqlConnection databaseConnection = new MySqlConnection(connectionString);
            MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);

            commandDatabase.CommandTimeout = 60;

            MySqlDataReader reader;

            databaseConnection.Open();

            reader = commandDatabase.ExecuteReader();

            databaseConnection.Close();
        }
        public void AtualizarAtrasados()
        {
            string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=livraria;";

            string query = "update locacao set atrasado = 1 where data_fim < now()";
            MySqlConnection databaseConnection = new MySqlConnection(connectionString);
            MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);

            commandDatabase.CommandTimeout = 60;

            MySqlDataReader reader;

            databaseConnection.Open();

            reader = commandDatabase.ExecuteReader();

            databaseConnection.Close();

        }
        public void AtualizarDayDiff()
        {
            string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=livraria;";

            string query = "update locacao set dayDiff = datediff(now(), data_fim) where atrasado = 1 and terminado = 0";
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

            databaseConnection.Close();
            
        }
        public void AtualizarValorTaxa()
        {
            string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=livraria;";

            string query = "update locacao set taxa = dayDiff*0.5 where terminado = 0 and atrasado = 1";
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

            databaseConnection.Close();

        }
        public void AcharAdm()
        { 
            string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=livraria;";

            string query = "SELECT idAdm FROM Adm where email = '" + Email.Text + "' AND senha = " + Senha.Text;

            MySqlConnection databaseConnection = new MySqlConnection(connectionString);
            MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);

            commandDatabase.CommandTimeout = 60;

            MySqlDataReader reader;

            databaseConnection.Open();
            reader = commandDatabase.ExecuteReader();


            if (reader.Read())
            {
                string[] row = { reader.GetString(0) };
                IdAdm = Convert.ToInt32(row[0]);
                MenuPrincipalAdm m1 = new MenuPrincipalAdm();
                this.Hide();
                m1.Show();

            }
        }
        public void AcharFuncionario()
        {
            string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=livraria;";

            string query = "SELECT idFuncionario FROM Funcionario where email = '" + Email.Text + "' AND estatus = 'ok' AND senha = " + Senha.Text;

            MySqlConnection databaseConnection = new MySqlConnection(connectionString);
            MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);

            commandDatabase.CommandTimeout = 60;

            MySqlDataReader reader;

            databaseConnection.Open();

            reader = commandDatabase.ExecuteReader();

            if (reader.Read())
            {
                string[] row = { reader.GetString(0) };
                IdFuncionario = Convert.ToInt32(row[0]);
                MenuPrincipalFuncionario m1 = new MenuPrincipalFuncionario();
                this.Hide();
                m1.Show();

            }

            databaseConnection.Close();
        }
        public void AcharCliente()
        {
            string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=livraria;";

            string query = "SELECT * FROM Cliente where email = '" + Email.Text + "' AND status = 'ok' AND senha = " + Senha.Text;

            MySqlConnection databaseConnection = new MySqlConnection(connectionString);
            MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);

            commandDatabase.CommandTimeout = 60;

            MySqlDataReader reader;

            databaseConnection.Open();

            reader = commandDatabase.ExecuteReader();

            if (reader.Read())
            {
                string[] row = { reader.GetString(0) };
                IdCliente = Convert.ToInt32(row[0]);
                MenuPrincipalCliente m1 = new MenuPrincipalCliente();
                this.Hide();
                m1.Show();

            }

            databaseConnection.Close();
        }
        public Login()
        {
            InitializeComponent();
        }
	/* NO MÉTODO LOAD DA TELA

	   MenuPrincipalFuncionario.FuncionarioB = False;
	   MenuPrincipalCliente.ClienteB = False;
	   MenuPrincipalAdm.AdmB = False;

	*/
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            AcharAdm();
            AcharFuncionario();
            AcharCliente();
            AtualizarChegadas();
            AtualizarAtrasados();
            AtualizarDayDiff();
            AtualizarValorTaxa();
            AtualizarRetiradosRetornados();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            MenuPrincipalFuncionario.FuncionarioB = false;
            MenuPrincipalCliente.ClienteB = false;
            MenuPrincipalAdm.AdmB = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (Senha.UseSystemPasswordChar)
            {
                button2.Text = "Esconder";
                Senha.UseSystemPasswordChar = false;
            }
            else
            {   
                button2.Text = "Ver";
                Senha.UseSystemPasswordChar = true;
            }
        }
    }
}

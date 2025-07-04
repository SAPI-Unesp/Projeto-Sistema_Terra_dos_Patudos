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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace projeto_locacao
{
    public partial class CadastrarCliente : Form
    {
        public CadastrarCliente()
        {
            InitializeComponent();
        }
        public bool conferirA()
        {
            string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=livraria;";

            string query = "SELECT idAdm from adm where email = '" + Email.Text + "' and senha = '" + Senha.Text + "'";

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

                        return true;
                    }
                }
                databaseConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
            return false;
        }
        public bool conferirF()
        {
            string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=livraria;";

            string query = "SELECT idFuncionario from funcionario where email = '" + Email.Text + "' and senha = '" + Senha.Text + "'";

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

                        return true;
                    }
                }
                databaseConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
            return false;
        }
        public bool conferir()
        {
            string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=livraria;";

            string query = "SELECT idCliente from cliente where email = '" + Email.Text + "' and senha = '" + Senha.Text + "'";

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
 
                        return true;
                    }
                }
                databaseConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
            return false;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (conferir() || conferirA() || conferirF())
            {
                MessageBox.Show("Já existe");
            }
            else
            {
                string connectionString = "datasource=localhost;port=3306;username=root;password=;database=livraria;";

                string query = "INSERT INTO cliente values (NULL, '" + Nome.Text + "', '" + Email.Text + "', '" + Senha.Text + "', '" + Cpf.Text + "', '" + Cep.Text + "', '" + NumeroCasa.Text + "', '" + Complemento.Text + "', '" + Apelido.Text + "', 'ok')";


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
                Funcionario f1 = new Funcionario();
                f1.ChamarMenuPrincipal();
                this.Hide();
            }
        }

        private void CadastrarCliente_Load(object sender, EventArgs e)
        {
           
        }
    }
}

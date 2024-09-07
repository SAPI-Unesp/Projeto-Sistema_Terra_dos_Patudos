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
    public partial class RetirarCliente : Form
    {
        public RetirarCliente()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MenuPrincipalFuncionario m1 = new MenuPrincipalFuncionario();
            m1.Show();
            this.Hide();
        }
        public void updateClienteRetirado()
        {
            string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=livraria;";

            string query = "update cliente set status = 'retirado' where idCliente = " + IdCliente.Text;
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
        private void button1_Click(object sender, EventArgs e)
        {
            string connectionString = "datasource=localhost;port=3306;username=root;password=;database=livraria;";
            string query = "INSERT INTO mr_cliente values (" + IdCliente.Text + ", '" + MotivoRetirada.Text + "')";
            MySqlConnection databaseConnection = new MySqlConnection(connectionString);

            MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);

            commandDatabase.CommandTimeout = 60;


            try
            {
                databaseConnection.Open();

                MySqlDataReader myReader = commandDatabase.ExecuteReader();
                databaseConnection.Close();
                updateClienteRetirado();
                Funcionario f1 = new Funcionario();
                f1.ChamarMenuPrincipal();
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}

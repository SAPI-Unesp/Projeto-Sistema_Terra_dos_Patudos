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
    public partial class EditarPerfilCliente : Form
    {
        public EditarPerfilCliente()
        {
            InitializeComponent();
        }
        public static string IdClienteC { get; set; }
        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
	        string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=livraria;";
    
	        string query = "UPDATE cliente set nome = '" + Nome.Text + "', email = '" + Email.Text + "', senha = '" + Senha.Text + "', cpf = '" + Cpf.Text + "', cep = '" + Cep.Text + "', numeroCasa = '" + NumeroCasa.Text + "', complemento = '" + Complemento.Text + "', apelido = '" + Apelido.Text + "' WHERE idCliente = '" + IdCliente.Text + "'";

            MySqlConnection databaseConnection = new MySqlConnection(connectionString);
            MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
    
            commandDatabase.CommandTimeout = 60;
    
    	    MySqlDataReader reader;

            try
            {
                databaseConnection.Open();
        
	            reader = commandDatabase.ExecuteReader();
        
                databaseConnection.Close();
                MessageBox.Show("Mudanças Salvas");

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
            catch (Exception ex)
            {
        
                MessageBox.Show("Algo deu errado durante a atualização dos dados, certifique-se que estão corretos");
            }
	   
        }
        private void label6_Click(object sender, EventArgs e)
        {
            

        }

        private void EditarPerfilCliente_Load(object sender, EventArgs e)
        {
            Cliente Cliente = new Cliente();

            string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=livraria;";

            string query = "SELECT * FROM Cliente where idCliente = " + IdClienteC;

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
                            reader.GetString(8)};
                        IdCliente.Text = row[0];
                        Nome.Text = row[1];
                        Email.Text = row[2];
                        Senha.Text = row[3];
                        Cpf.Text = row[4];
                        Cep.Text = row[5];
                        NumeroCasa.Text = row[6];
                        Complemento.Text = row[7];
                        Apelido.Text = row[8];

                    }
                }
                databaseConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}

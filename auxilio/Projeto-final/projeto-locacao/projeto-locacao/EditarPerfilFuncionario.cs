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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using MySql.Data.MySqlClient;

namespace projeto_locacao
{
    public partial class EditarPerfilFuncionario : Form
    {
        public EditarPerfilFuncionario()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

	        string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=livraria;";
    
	        string query = "UPDATE funcionario set nome = '" + Nome.Text + "', email = '" + Email.Text + "', " +
                "senha = '" + Senha.Text + "', cpf = '" + Cpf.Text + "', cep = " + Cep.Text + ", " +
                "numeroCasa = '" + NumeroCasa.Text + "', complemento = '" + Complemento.Text + "', " +
                "apelido = '" + Apelido.Text + "' WHERE idFuncionario = " + IdFuncionario.Text;

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
                Funcionario f1 = new Funcionario();
	
	            f1.ChamarMenuPrincipal(); 
                this.Hide();
            }
            catch (Exception ex)
            {
        
                MessageBox.Show("Algo deu errado durante a atualização dos dados, certifique-se que estão corretos");
            }
	   

        }

        private void EditarPerfilFuncionario_Load(object sender, EventArgs e)
        {
            Funcionario Funcionario1 = new Funcionario();

            string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=livraria;";

            string query = "SELECT * FROM Funcionario where idFuncionario = " + Login.IdFuncionario;

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
                            reader.GetString(5), reader.GetString(6), reader.GetString(7), reader.GetString(8), reader.GetString(9) };

                        Funcionario1.IdFuncionario = Convert.ToInt32(row[0]);
                        Funcionario1.Nome = row[1];
                        Funcionario1.Email = row[2];
                        Funcionario1.Senha = row[3];
                        Funcionario1.Cpf = row[4];
                        Funcionario1.Cep = row[5];
                        Funcionario1.NumeroCasa = row[6];
                        Funcionario1.Complemento = row[7];
                        Funcionario1.Apelido = row[8];
                        Funcionario1.Estatus = row[9];

                        IdFuncionario.Text = Convert.ToString(Funcionario1.IdFuncionario);
                        Nome.Text = Funcionario1.Nome;
                        Email.Text = Funcionario1.Email;
                        Senha.Text = Funcionario1.Senha;
                        Cpf.Text = Funcionario1.Cpf;
                        Cep.Text = Funcionario1.Cep;
                        NumeroCasa.Text = Funcionario1.NumeroCasa;
                        Complemento.Text = Funcionario1.Complemento;
                        Apelido.Text = Funcionario1.Apelido;
                        Estatus.Text = Funcionario1.Estatus;
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

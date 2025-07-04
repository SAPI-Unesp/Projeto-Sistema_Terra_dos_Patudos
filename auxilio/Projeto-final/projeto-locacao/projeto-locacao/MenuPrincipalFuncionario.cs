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

    public partial class MenuPrincipalFuncionario : Form
    {
	    public static bool FuncionarioB{get;set;}

        public MenuPrincipalFuncionario()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            LocacoesFuncionario l1 = new LocacoesFuncionario();
            l1.Show();
            this.Hide();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            ProcurarClienteFuncionario p1 = new ProcurarClienteFuncionario();
            p1.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Devolucoes d1 = new Devolucoes();
            d1.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            EditarPerfilFuncionario e1 = new EditarPerfilFuncionario();
            e1.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Relatorio r1 = new Relatorio();
            r1.Show();
            this.Hide();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            LivroFuncionario l1 = new LivroFuncionario();
            l1.Show();
            this.Hide();
        }

        private void MenuPrincipalFuncionario_Load(object sender, EventArgs e)
        {
            Funcionario Funcionario1 = new Funcionario();
            FuncionarioB = true;
           
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

                        Olaapelido.Text = "Olá, " + Funcionario1.Apelido;
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
            Login l1 = new Login();
            l1.Show();
            this.Hide();
        }
    }
}

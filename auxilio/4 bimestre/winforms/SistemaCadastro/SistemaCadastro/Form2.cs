using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace SistemaCadastro
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string connectionString = "datasource=localhost;port=3306;username=root;password=;database=banco;";

            string query = "SELECT * FROM login where usuario = '"+ textBox1.Text + "' and senha = '"+ textBox2.Text +"' ";

            MySqlConnection databaseConnection = new MySqlConnection(connectionString);
            databaseConnection.Open();
            MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
            commandDatabase.CommandTimeout = 60;

            MySqlDataReader reader = commandDatabase.ExecuteReader();

            if(reader.Read())
            {
                Form1 form1 =  new Form1();
                form1.Show();
                this.Hide();
                MessageBox.Show("Login Efetuado com sucesso!!", "Bem vindo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            } else
            {
                MessageBox.Show("Dados Inválidos!!", "Acesso negado", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            textBox1.Text = string.Empty;
            textBox2.Text = string.Empty;
            reader.Close();
            commandDatabase.Dispose();

            try
            {
                databaseConnection.Open();

                reader = commandDatabase.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {

                        string[] row = { reader.GetString(0), reader.GetString(1), reader.GetString(2) };
                        textBox1.Text = row[0];
                        textBox1.Text = row[1];
                        textBox1.Text = row[2];
                    }
                }
                else
                {
                    MessageBox.Show("Não ha registros");
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

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

namespace SistemaVenda
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string connectionString = "datasource=localhost;port=3306;username=root;password=;database=sistemavenda;";

            string query = "SELECT * FROM login where id = '" + textBox1.Text + "' and senha = '" + textBox2.Text + "' ";

            MySqlConnection databaseConnection = new MySqlConnection(connectionString);
            databaseConnection.Open();
            MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
            commandDatabase.CommandTimeout = 60;

            MySqlDataReader reader = commandDatabase.ExecuteReader();

            if (reader.Read())
            {
                Form2 form2 = new Form2();
                form2.Show();
                this.Hide();
                MessageBox.Show("Login Efetuado com sucesso!!", "Bem vindo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
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
                    MessageBox.Show("Não há registros");
                }

                databaseConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            form3.Show();
            this.Hide();
        }
    }
}

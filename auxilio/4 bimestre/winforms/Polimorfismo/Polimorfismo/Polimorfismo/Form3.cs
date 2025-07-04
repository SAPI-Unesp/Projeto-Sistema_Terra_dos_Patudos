using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Polimorfismo
{
    public partial class Form3 : Form
    {
        class Circulo
        {
            public double Raio { get; set; }
            public double Area { get; set; }

            public void CalcularCirculo()
            {
                this.Area = (this.Raio * this.Raio) * 3.14;
            }
        }
        public Form3()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Circulo c = new Circulo();

            c.Raio = Convert.ToDouble(textBox1.Text);

            textBox2.Text = Convert.ToString(c.Area);

            string connectionString = "datasource=localhost;port=3306;username=root;password=;database=bi3011852;";

            string query = "INSERT INTO circulo VALUES ('" + textBox1.Text + "', '" + textBox2.Text + "')";

            MySqlConnection databaseConnection = new MySqlConnection(connectionString);

            MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);

            commandDatabase.CommandTimeout = 60;

            try
            {

                databaseConnection.Open();
                MySqlDataReader myReader = commandDatabase.ExecuteReader();

                MessageBox.Show("Valor salvo na nuvem");

                databaseConnection.Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            listBox1.Items.Clear();
            listBox1.Items.Clear();
            listBox1.Items.Clear();

            string connectionString = "datasource=localhost;port=3306;username=root;password=;database=bi3011852;";

            string query = "SELECT * FROM circulo";

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

                        string[] row = { reader.GetString(0), reader.GetString(1) };
                        listBox1.Items.Add("-------------------------------");
                        listBox1.Items.Add("Raio: " + row[0]);
                        listBox1.Items.Add("Área: " + row[1]);
                        listBox1.Items.Add("-------------------------------");
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

        private void button4_Click(object sender, EventArgs e)
        {
            string connectionString = "datasource=localhost;port=3306;username=root;password=;database=bi3011852;";


            string query = "TRUNCATE TABLE `circulo`;";

            MySqlConnection databaseConnection = new MySqlConnection(connectionString);
            MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);

            commandDatabase.CommandTimeout = 60;

            MySqlDataReader reader;

            try
            {
                databaseConnection.Open();

                reader = commandDatabase.ExecuteReader();

                databaseConnection.Close();

                MessageBox.Show("Todos os dados foram deletados");
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
    }
}

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

namespace Polimorfismo
{
    public partial class Form2 : Form
    {
        class Quadrado
        {
            public double Lado1 { get; set; }
            public double Lado2 { get; set; }
            public double Area { get; set; }

            public void calcularQuadrado()
            {
                this.Area = this.Lado1 * this.Lado2;
            }
        }
        public Form2()
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
            Quadrado q = new Quadrado();

            q.Lado1 = Convert.ToDouble(textBox1.Text);
            q.Lado2 = Convert.ToDouble(textBox2.Text);

            textBox3.Text = Convert.ToString(q.Area);

            string connectionString = "datasource=localhost;port=3306;username=root;password=;database=bi3011852;";

            string query = "INSERT INTO quadrado VALUES ('" + textBox1.Text + "', '" + textBox2.Text + "', '" + textBox3.Text + "')";
           
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

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            listBox1.Items.Clear();
            listBox1.Items.Clear();
            listBox1.Items.Clear();
            listBox1.Items.Clear();

            string connectionString = "datasource=localhost;port=3306;username=root;password=;database=bi3011852;";

            string query = "SELECT * FROM quadrado";

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

                        string[] row = { reader.GetString(0), reader.GetString(1), reader.GetString(2) };
                        listBox1.Items.Add("-------------------------------");
                        listBox1.Items.Add("Lado1: " + row[0]);
                        listBox1.Items.Add("Lado2: " + row[1]);
                        listBox1.Items.Add("Área: " + row[2]);
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

            string query = "TRUNCATE TABLE `quadrado`;";

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

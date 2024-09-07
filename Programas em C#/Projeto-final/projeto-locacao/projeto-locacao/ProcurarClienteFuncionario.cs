using MySql.Data.MySqlClient;
using System;
using System.Collections;
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
    public partial class ProcurarClienteFuncionario : Form
    {
        public ProcurarClienteFuncionario()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            LocacoesFuncionario l1 = new LocacoesFuncionario();
            l1.Show();
            this.Hide();
        }
        public void gerarDevolucoes()
        {
            listBox3.Items.Clear();
            string connectionString = "datasource=localhost;port=3306;username=root;password=;database=livraria;";
            string query = "SELECT * FROM devolucao, locacao where devolucao.idLocacao = locacao.idLocacao and locacao.fk_idCliente = " + IdCliente.Text;

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


                    string[] row = { reader.GetString(0), reader.GetString(1) };

                    listBox3.Items.Add("----------------------------");
                    listBox3.Items.Add(" ");
                    listBox3.Items.Add("Id Devolução: " + row[1]);
                    listBox3.Items.Add("Data de Fim: " + row[0]);
                }

            }
        }
        public void gerarLocacoesAtivas()
        {
            string connectionString = "datasource=localhost;port=3306;username=root;password=;database=livraria;";

            listBox1.Items.Clear();
            string query = "SELECT * FROM locacao where atrasado = 0 and terminado = 0 and fk_idCliente = " + IdCliente.Text;


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


                    string[] row = { reader.GetString(0), reader.GetString(1), reader.GetString(2),
                    reader.GetString(3), reader.GetString(4), reader.GetString(5),
                    reader.GetString(6), reader.GetString(7), reader.GetString(8)};

                    listBox1.Items.Add("----------------------------");
                    listBox1.Items.Add(" ");
                    listBox1.Items.Add("Id Locação: " + row[0]);

                    listBox1.Items.Add("Data de Início: " + row[1]);

                    listBox1.Items.Add("Data de Fim: " + row[2]);
                    listBox1.Items.Add("Atrasado: " + row[3]);

                    listBox1.Items.Add("Taxa: " + row[4]);

                    listBox1.Items.Add("Id Cliente: " + row[5]);
                    listBox1.Items.Add("Id Funcionario: " + row[6]);

                    listBox1.Items.Add("Id Livro: " + row[7]);

                    listBox1.Items.Add("Terminado: " + row[8]);
                    listBox1.Items.Add(" ");

                }
            }
        }
            public void procurarLocacoes()
        {
            gerarLocacoesAtivas();
            gerarDevolucoes();
            listBox2.Items.Clear();
            string connectionString = "datasource=localhost;port=3306;username=root;password=;database=livraria;";


            string query = "SELECT * FROM locacao where atrasado = 1 and terminado = 0 and fk_idCliente = " + IdCliente.Text;


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


                    string[] row = { reader.GetString(0), reader.GetString(1), reader.GetString(2),
                    reader.GetString(3), reader.GetString(4), reader.GetString(5),
                    reader.GetString(6), reader.GetString(7), reader.GetString(8), reader.GetString(9)};

                    listBox2.Items.Add("----------------------------");
                    listBox2.Items.Add(" ");
                    listBox2.Items.Add("Id Locação: " + row[0]);

                    listBox2.Items.Add("Data de Início: " + row[1]);

                    listBox2.Items.Add("Data de Fim: " + row[2]);
                    listBox2.Items.Add("Atrasado: " + row[3]);

                    listBox2.Items.Add("Taxa: " + row[4]);

                    listBox2.Items.Add("Id Cliente: " + row[5]);
                    listBox2.Items.Add("Id Funcionario: " + row[6]);

                    listBox2.Items.Add("Id Livro: " + row[7]);

                    listBox2.Items.Add("Terminado: " + row[8]);
                    listBox2.Items.Add(" ");

                }

            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            EditarPerfilCliente.IdClienteC = IdCliente.Text;
            EditarPerfilCliente e1 = new EditarPerfilCliente();
            e1.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ProcurarClientePorNomeFuncionario.SortaName = NomeSorta.Text;
            ProcurarClientePorNomeFuncionario p1 = new ProcurarClientePorNomeFuncionario();
            p1.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Devolucoes d1 = new Devolucoes();
            d1.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Cliente Cliente = new Cliente();

            string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=livraria;";

            string query = "SELECT * FROM Cliente where idCliente = " + IdCliente.Text;

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
                        reader.GetString(8), reader.GetString(9)};
                        Cliente.IdCliente = Convert.ToInt32(row[0]);
                        Cliente.Nome = row[1];
                        Cliente.Email = row[2];
                        Cliente.Senha = row[3];
                        Cliente.Cpf = row[4];
                        Cliente.Cep = row[5];
                        Cliente.NumeroCasa = row[6];
                        Cliente.Complemento = row[7];
                        Cliente.Apelido = row[8];
                        Cliente.Status = row[9];

                        IdClienteTxt.Text = row[0];
                        Nome.Text = row[1];
                        Email.Text = row[2];
                        Senha.Text = row[3];
                        Cpf.Text = row[4];
                        Cep.Text = row[5];
                        NumeroCasa.Text = row[6];
                        Complemento.Text = row[7];
                        Apelido.Text = row[8];
                        Estatus.Text = row[9];

                        procurarLocacoes();

                    }
                }
                databaseConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            CadastrarCliente c1 = new CadastrarCliente();
            c1.Show();
            this.Hide();
        }

        private void ProcurarClienteFuncionario_Load(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            MenuPrincipalFuncionario m1 = new MenuPrincipalFuncionario();
            m1.Show();
            this.Hide();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            RetirarCliente r1 = new RetirarCliente();
            r1.Show();
            this.Hide();
        }
    }
}

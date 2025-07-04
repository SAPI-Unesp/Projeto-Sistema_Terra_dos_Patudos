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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace projeto_locacao
{
    public partial class LivroFuncionario : Form
    {
	    public static int IdLivroE {get; set;} // PODE DAR PROBLEMA
        public static string IdLocacao { get; set; }

        public LivroFuncionario()
        {
            InitializeComponent();
        }
        public void procurarMR()
        {
            string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=livraria;";

            string query = "SELECT motivo FROM mr_livro where idLivro = " + IdLivro.Text;

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

                        string[] row = { reader.GetString(0) };
                        richTextBox1.Text = row[0];
                    }
                }
                databaseConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MenuPrincipalFuncionario m1 = new MenuPrincipalFuncionario();
            m1.Show();
            this.Hide();
        }
        public void gerarLocacoesTodas()
        {
            string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=livraria;";

            string query = "SELECT class_nome, class_id FROM classificacao";

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
                        comboBox2.Items.Add(row[0]);
                        listBox3.Items.Add(row[1] + "   " + row[0]);
                    }
                }
                databaseConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void AtualizarChegadas()
        {
            string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=livraria;";

            string query = "update locacao set terminado = 1 where idLocacao = " + IdLocacao;
            MySqlConnection databaseConnection = new MySqlConnection(connectionString);
            MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);

            commandDatabase.CommandTimeout = 60;

            MySqlDataReader reader;

            databaseConnection.Open();

            reader = commandDatabase.ExecuteReader();

            databaseConnection.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ProcurarLivroPorNome.SortaName = Nome.Text;
            ProcurarLivroPorNome l1 = new ProcurarLivroPorNome();
            l1.Show();
        }
        public void GerarDevolucao()
        {
            string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=livraria;";

            string query = "insert into devolucao values (now(), " + IdLocacao + ")";

            MySqlConnection databaseConnection = new MySqlConnection(connectionString);
            MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);

            commandDatabase.CommandTimeout = 60;

            MySqlDataReader reader;

            try
            {
                databaseConnection.Open();

                reader = commandDatabase.ExecuteReader();

                AtualizarChegadas();

                databaseConnection.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void AcharLocacao()
        {
            string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=livraria;";

            string query = "select idLocacao from locacao where fk_idLivro = "+IdLivro.Text+" and terminado = 0";

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

                        string[] row = { reader.GetString(0)};
                        IdLocacao = row[0];
                        MessageBox.Show("Locação Encontrada");
                        GerarDevolucao();

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
            string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=livraria;";

            string query = "SELECT * FROM Livro where idLivro = '" + IdLivro.Text + "'";

            MySqlConnection databaseConnection = new MySqlConnection(connectionString);
            MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);

            commandDatabase.CommandTimeout = 60;

            MySqlDataReader reader;

            try
            {
                databaseConnection.Open();

                reader = commandDatabase.ExecuteReader();

                if (reader.Read())
                {
                    InformacoesLivro.IdLivro = Convert.ToInt32(IdLivro.Text);

                    InformacoesLivro f1 = new InformacoesLivro();
                    f1.Show();
                    this.Hide();
                }
                databaseConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Livro Não Encontrado");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
	        string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=livraria;";

            string query = "SELECT * FROM Livro where idLivro = " + Convert.ToInt32(IdLivro.Text);

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
		            IdLivroE = Convert.ToInt32(IdLivro.Text);

            	    EditarLivro f1 = new EditarLivro();
            	    f1.Show();
		            this.Hide();
                }
                databaseConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Livro Não Encontrado");
            }
        }

        private void LivroFuncionario_Load(object sender, EventArgs e)
        {
            gerarLocacoesTodas();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Funcionario f1 = new Funcionario();
            string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=livraria;";

            string query = "UPDATE livro set status = 'disponivel' where idLivro = " + IdLivro.Text;

            MySqlConnection databaseConnection = new MySqlConnection(connectionString);
            MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);

            commandDatabase.CommandTimeout = 60;

            MySqlDataReader reader;

            try
            {
                databaseConnection.Open();

                reader = commandDatabase.ExecuteReader();

                databaseConnection.Close();

                AcharLocacao();
                MessageBox.Show("Livro Disponibilizado");
                


                f1.ChamarMenuPrincipal();
                this.Hide();
            }
            catch (Exception ex)
            {

                MessageBox.Show("Livro não atualizado");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            listBox1.Items.Clear(); // -------

            string connectionString = "datasource=localhost;port=3306;username=root;password=;database=livraria;";

            string query;
            string ordem = "";
            if (comboBox1.Text == "Mais Velhos") { ordem = "order by data_chegada asc"; }
            if (comboBox1.Text == "Mais Novos") { ordem = "order by data_chegada desc"; }
            query = "SELECT idLivro, titulo, autor, data_chegada, status FROM livro " + ordem;


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


                    string[] row = { reader.GetString(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4) };

                    listBox1.Items.Add("----------------------------");
                    listBox1.Items.Add(" ");
                    listBox1.Items.Add("Id: " + row[0]);

                    listBox1.Items.Add("Nome: " + row[1]);

                    listBox1.Items.Add("Autor: " + row[2]);
                    listBox1.Items.Add("Data Chegada: " + row[3]);
                    listBox1.Items.Add("Status: " + row[4]);
                    listBox1.Items.Add(" ");

                }

            }

            else
            {

                listBox1.Items.Clear(); // -------
                listBox1.Items.Add("Não há livros disponíveis");
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=livraria;";

            string query = "SELECT idLivro, titulo, autor FROM livro";

            if (comboBox1.Text != "categoria")
            {
                query = "SELECT livro.idLivro, livro.titulo, livro.autor FROM livro " +
                    "join classifLivro on classifLivro.fk_idLivro = livro.idLivro " +
                    "join classificacao on classifLivro.fk_class_id = classificacao.class_id " +
                    "where classificacao.class_nome = '" + comboBox2.Text + "'";
            }

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
                        listBox1.Items.Add("Código = " + row[0]);
                        listBox1.Items.Add("Nome = " + row[1]);
                        listBox1.Items.Add("Autor = " + row[2]);
                        listBox1.Items.Add(" ");
                        listBox1.Items.Add("-----------------------");

                    }
                }
                databaseConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            CadastrarClassificacao c1 = new CadastrarClassificacao();
            c1.Show();
            this.Hide();
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {
            procurarMR();
            listBox2.Items.Clear();
            string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=livraria;";

            string query = "select classificacao.class_nome, classificacao.class_id from classificacao join " +
                "classiflivro on classificacao.class_id = classiflivro.fk_class_id " +
                "where classiflivro.fk_idLivro = " + IdLivro.Text;

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
                        listBox2.Items.Add(row[1]+"     " + row[0]);

                    }
                }
                else
                {
                    MessageBox.Show("Não há classificações");
                }
                databaseConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button13_Click(object sender, EventArgs e)
        {
            DeletarClassificacao d1 = new DeletarClassificacao();
            d1.Show();
            this.Hide();
        }

        private void listBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button12_Click(object sender, EventArgs e)
        {
            //--------------

            string connectionString = "datasource=localhost;port=3306;username=root;password=;database=livraria;";
            string query = "INSERT INTO classiflivro values (" + IdLivro.Text + ", " + IdClassifAdd.Text + ")";
            MySqlConnection databaseConnection = new MySqlConnection(connectionString);

            MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);

            commandDatabase.CommandTimeout = 60;


            try
            {
                databaseConnection.Open();

                MySqlDataReader myReader = commandDatabase.ExecuteReader();
                databaseConnection.Close();
                Funcionario f1 = new Funcionario();
                f1.ChamarMenuPrincipal();
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            string connectionString = "datasource=localhost;port=3306;username=root;password=;database=livraria;";
            string query = "delete from classiflivro where fk_class_id = " + IdClassifDel.Text + " and fk_idLivro = " + IdLivro.Text;
            MySqlConnection databaseConnection = new MySqlConnection(connectionString);

            MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);

            commandDatabase.CommandTimeout = 60;

            try
            {
                databaseConnection.Open();

                MySqlDataReader myReader = commandDatabase.ExecuteReader();
                databaseConnection.Close();
                Funcionario f1 = new Funcionario();
                f1.ChamarMenuPrincipal();
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            CadastrarLivro c1 = new CadastrarLivro();
            c1.Show();
            this.Hide();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            RetirarLivro r1 = new RetirarLivro();
            r1.Show();
            this.Hide();
        }
    }
}

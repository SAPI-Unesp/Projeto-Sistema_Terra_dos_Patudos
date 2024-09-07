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
    public partial class ProcurarLocacao : Form
    {
        public ProcurarLocacao()
        {
            InitializeComponent();
        }
        public static string IdLocacao { get; set; }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (MenuPrincipalCliente.ClienteB)
            {
                Cliente Cliente = new Cliente();
                Cliente.ChamarMenuPrincipal();
                this.Hide();
            }
            if (MenuPrincipalFuncionario.FuncionarioB)
            {
                Funcionario Funcionario = new Funcionario();
                Funcionario.ChamarMenuPrincipal();
                this.Hide();
            }
        }

        private void ProcurarLocacaoCliente_Load(object sender, EventArgs e)
        {
            string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=livraria;";

            string query = "select livro.titulo, locacao.data_inicio, locacao.data_fim, funcionario.nome, locacao.idLocacao from locacao " +
                "join livro on livro.idLivro = locacao.fk_idLivro " +
                "join funcionario on funcionario.idFuncionario = locacao.fk_idFuncionario " +
                "where idLocacao = " + IdLocacao;

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
                            reader.GetString(2), reader.GetString(3), reader.GetString(4)};

                        Titulo.Text = row[0];
                        Data_inicio.Text = row[1];
                        Data_fim.Text= row[2];
                        Funcionario_At.Text = row[3];
                        IdLocacaoT.Text = row[4];

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

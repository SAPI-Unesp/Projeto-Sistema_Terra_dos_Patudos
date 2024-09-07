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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace projeto_locacao
{
    public partial class InformacoesLivro : Form
    {
	public static int IdLivro{get;set;}
	public Livro Livro {get;set;}

        public InformacoesLivro()
        {
            InitializeComponent();
        }
        public void procurarMRMess()
        {
            string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=livraria;";

            string query = "SELECT motivo FROM mr_livro where idLivro = " + Convert.ToString(IdLivro);

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
                        MessageBox.Show(row[0]);
                    }
                }
                databaseConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if(MenuPrincipalCliente.ClienteB){
                Cliente Cliente = new Cliente();
	            Cliente.ChamarMenuPrincipal();
	            this.Hide();
            }
            if(MenuPrincipalFuncionario.FuncionarioB){
                Funcionario Funcionario = new Funcionario();
	            Funcionario.ChamarMenuPrincipal();
	            this.Hide();
            }
        }

        private void InformacoesLivro_Load(object sender, EventArgs e)
        {
            if(MenuPrincipalFuncionario.FuncionarioB) procurarMRMess();

            string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=livraria;";

            string query = "SELECT * FROM livro where idLivro = " + Convert.ToString(IdLivro);

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

                        string[] row = { reader.GetString(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4), reader.GetString(5), reader.GetString(6), reader.GetString(7), reader.GetString(8) };
                        IdLivroT.Text = row[0];   // textBox
                        Titulo.Text = row[1];
                        Autor.Text = row[2];
                        Editora.Text = row[3];
                        Data_chegada.Text = row[4];
                        Qtd_paginas.Text = row[5];
                        Valor_locacao.Text = row[6];
                        Fk_idFuncionario.Text = row[7];
                        Estatus.Text = row[8];

                        Livro.IdLivro = Convert.ToInt32(row[0]);
                        Livro.Titulo = Titulo.Text;
                        Livro.Autor = Autor.Text;
                        Livro.Editora = Editora.Text;
                        Livro.Data_chegada = Data_chegada.Text;
                        Livro.Qtd_paginas = Convert.ToInt32(Qtd_paginas.Text);
                        Livro.Valor_locacao = Valor_locacao.Text;
                        Livro.Fk_idFuncionario = Convert.ToInt32(Fk_idFuncionario.Text);
                        Livro.Estatus = Estatus.Text;

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

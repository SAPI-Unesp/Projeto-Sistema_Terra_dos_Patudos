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
    public partial class CadastrarLivro : Form
    {
        public CadastrarLivro()
        {
            InitializeComponent();
        }

        private void CadastrarLivro_Load(object sender, EventArgs e)
        {
            Fk_idFuncionario.Text = Convert.ToString(Login.IdFuncionario);
            Estatus.Text = "disponivel";

            string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=livraria;";

            string query = "select now(), max(idLivro + 1) from livro";

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
                        Data_chegada.Text = row[0];
                        IdLivro.Text = row[1];

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
            string connectionString = "datasource=localhost;port=3306;username=root;password=;database=livraria;";
            string query = "INSERT INTO livro values (NULL, '" + Titulo.Text + "', '" + Autor.Text + "', '" + Editora.Text + "', now(), " + Qtd_paginas.Text + ", " + Valor_locacao.Text + ", " + Fk_idFuncionario.Text + ", '" + Estatus.Text + "')";
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

        private void button2_Click(object sender, EventArgs e)
        {
            MenuPrincipalFuncionario m1 = new MenuPrincipalFuncionario();
            m1.Show();
            this.Hide();
        }
    }
}

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
    public partial class EditarLivro : Form
    {
        public static Livro Livro;
        public EditarLivro()
        {
            InitializeComponent();
        }
	    /*  
		NESSA TELA, É NECESSÁRIO COLOCAR TODOS ATRIBUTOS DE LIVROS, JÁ QUE OS TEXTBOX FORAM COPIADOS DO CLIENTE, 
                ENTÃO MUDE OS NOMES E ADICIONE OS QUE FALTAM
		PARA QUE TUDO FUNCIONE, É NECESSÁRIO MUDAR OS NAMES DOS TEXTBOX PARA SEUS ATRIBUTOS DE ACORDO COM O BANCO, SEMPRE COMEÇANDO POR LETRA MAIÚSCULA
		O CÓDIGO ABAIXO SÓ VAI FUNCIONAR SE A CLASSE LIVRO ESTIVER CRIADA NO SISTEMA 


		LEMBRAR DE COLOCAR FK_IDFUNCIONARIO E DATA DE CHEGADA COMO DISABLED
	    */

            /* NO METODO LOAD
 	    
	   */

        private void button1_Click(object sender, EventArgs e)
        {
            Funcionario f1 = new Funcionario();
	    string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=livraria;";
    
	    string query = "UPDATE livro set titulo = '" + Titulo.Text + "', autor = '" + Autor.Text + "', editora = '" + Editora.Text + "', qtd_paginas = '" + Qtd_paginas.Text + "', valor_locacao = '" + Valor_locacao.Text + "', status = '" + Estatus.Text + "' WHERE idLivro = '" + IdLivro.Text + "'";

            MySqlConnection databaseConnection = new MySqlConnection(connectionString);
            MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
    
            commandDatabase.CommandTimeout = 60;
    
    	    MySqlDataReader reader;

            try
            {
                databaseConnection.Open();

                reader = commandDatabase.ExecuteReader();

                databaseConnection.Close();
                MessageBox.Show("Mudanças Salvas");
        

                f1.ChamarMenuPrincipal();
                this.Hide();
            }
            catch (Exception ex)
            {

                MessageBox.Show("Algo deu errado durante a atualização dos dados, certifique-se que estão corretos");
            }
        }

        private void EditarLivro_Load(object sender, EventArgs e)
        {
            string connectionString = "datasource=localhost;port=3306;username=root;password=;database=livraria;";

            string query = "SELECT * FROM livro where idLivro = " + Convert.ToString(LivroFuncionario.IdLivroE);

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
                        IdLivro.Text = row[0];   // textBox
                        Titulo.Text = row[1];
                        Autor.Text = row[2];
                        Editora.Text = row[3];
                        Data_chegada.Text = row[4];
                        Qtd_paginas.Text = row[5];
                        Valor_locacao.Text = row[6];
                        Fk_idFuncionario.Text = row[7];
                        Estatus.Text = row[8];

                        Livro.IdLivro = Convert.ToInt32(IdLivro.Text);
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

using CadastroBanco;
using System;
using System.IO;
using System.Windows.Forms;

namespace CadastroBanco
{
    public partial class FormAdicionar : Form
    {
        private Form2 formPrincipal; // Referência ao Form1 (formulário principal)
        string caminhoArquivo = "dados.txt"; // Mesmo arquivo usado no Form1

        public FormAdicionar(Form2 form)
        {
            InitializeComponent();
            this.formPrincipal = form; // Recebe a referência do Form1
        }

        // Botão para confirmar e adicionar os dados ao arquivo TXT
        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            
        }

        private void FormAdicionar_Load(object sender, EventArgs e)
        {

        }

        private void btnConfirmar_Click_1(object sender, EventArgs e)
        {
            string categoria = cbCategoria.Text;
            string descricao = txtDesc.Text;
            decimal qnt = numQnt.Value;
            decimal preco = numPreco.Value;

            if (string.IsNullOrWhiteSpace(categoria))
            {
                MessageBox.Show("Preencha a categoria.");
                return;
            }

            // Adiciona ao arquivo
            File.AppendAllText(caminhoArquivo, $"{categoria}, {descricao}, {qnt}, {preco}{Environment.NewLine}");
            MessageBox.Show("Dados adicionados com sucesso!");

            // Atualiza o DataGridView no formulário principal
            formPrincipal.ExibirDados();

            // Fecha o formulário de adição após a inserção
            this.Close();
        }
    }
}

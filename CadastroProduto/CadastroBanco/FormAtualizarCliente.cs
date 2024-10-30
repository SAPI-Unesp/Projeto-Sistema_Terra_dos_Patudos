using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CadastroBanco
{
    public partial class FormAtualizarCliente : Form
    {
        string caminhoArquivo = "dados.txt"; // Arquivo onde os dados serão armazenados
        string caminhoArquivoVendas = "Vendas.txt"; // Arquivo onde os dados serão armazenados
        string caminhoArquivoCategoria = "categoria.txt";
        string caminhoArquivoCarrinho = "carrinho.txt";
        string caminhoArquivoCliente = "cliente.txt";
        string itensComId = "itensComId.txt";
        public string Cliente { get; private set; }
        public string Telefone { get; private set; }
        public decimal Credito { get; private set; }
        public FormAtualizarCliente(string id ,string clienteo, string telefone, decimal credito)
        {
            InitializeComponent();
            textBoxID.Text = id;
            textBoxCliente.Text = clienteo;
            textBoxTelefone.Text = telefone;
            numericUpDownCredito.Value = credito;
        }

        private void FormAtualizarCliente_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var linhas = File.ReadAllLines(caminhoArquivoCliente);

            foreach (var linha in linhas)
            {
                var dados = linha.Split('*');

                if (dados.Length == 6)
                {
                    string id = dados[0].Trim();
                    string cliente = dados[1].Trim();
                    string telefone = dados[2].Trim();
                    string divida = dados[3].Trim();
                    string desconto = dados[4].Trim();
                    string credito = dados[5].Trim();

                    if (cliente.Equals(textBoxCliente.Text) && !id.Equals(textBoxID.Text))
                    {
                        MessageBox.Show("Esse cliente já existe!!!");
                        return;
                    }

                }
            }

            Cliente = textBoxCliente.Text;
            Telefone = textBoxTelefone.Text;
            Credito = numericUpDownCredito.Value;

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}

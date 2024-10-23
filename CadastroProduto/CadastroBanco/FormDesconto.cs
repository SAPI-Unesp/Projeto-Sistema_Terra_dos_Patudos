using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace CadastroBanco
{
    public partial class FormDesconto : Form
    {
        public string caminhoArquivoCliente = "cliente.txt";
        public decimal Desconto { get; set; }
        public string Cliente { get; set; }
        private List<string[]> clientes = new List<string[]>();

        public FormDesconto()
        {
            InitializeComponent();
            if (File.Exists(caminhoArquivoCliente))
            {
                var linhas = File.ReadAllLines(caminhoArquivoCliente);
                foreach (var linha in linhas)
                {
                    var dadosCliente = linha.Split('*');
                    if (dadosCliente.Length > 1)
                    {
                        cbCliente.Items.Add(dadosCliente[1].Trim());
                    }
                }
            }
            ExibirDados();





        }


        private void dataGridViewDados_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void cbCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            Cliente = cbCliente.Text;
            ExibirDados();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Desconto = valor.Value; 
            Cliente = cbCliente.Text;

            List<string> linhasClientes = File.Exists(caminhoArquivoCliente)
                ? File.ReadAllLines(caminhoArquivoCliente).ToList()
                : new List<string>();


            for (int i = 0; i < linhasClientes.Count; i++)
            {
                var dadosCliente = linhasClientes[i].Split('*');

                if (dadosCliente.Length < 5) continue;

                string id = dadosCliente[0].Trim();
                string cliente = dadosCliente[1].Trim();
                string valorDivida = dadosCliente[2].Trim();
                decimal desconto = Convert.ToDecimal(dadosCliente[3].Trim());
                string credito = dadosCliente[4].Trim();

                if (Cliente == cliente)
                {
                    desconto += Desconto; 
                    linhasClientes[i] = $"{id}*{cliente}*{valorDivida}*{desconto}*{credito}"; 
                    break; 
                }
            }

            File.WriteAllLines(caminhoArquivoCliente, linhasClientes);
            valor.Value = 0; 
            cbCliente.Text = "";
            ExibirDados();

        }

        public void ExibirDados()
        {

            clientes.Clear();
            dataGridViewDados.Rows.Clear();

            if (File.Exists(caminhoArquivoCliente))
            {
                var linhas = File.ReadAllLines(caminhoArquivoCliente);
                foreach (var linha in linhas)
                {
                    var dadosCliente = linha.Split('*');

                    if (dadosCliente.Length < 5) continue; 

                    clientes.Add(new string[]
                    {
                    dadosCliente[0].Trim(), 
                    dadosCliente[1].Trim(), 
                    dadosCliente[2].Trim(), 
                    dadosCliente[3].Trim(), 
                    dadosCliente[4].Trim()  
                    });
                }

                List<string[]> clientesFiltrados = Cliente == "Todos" || string.IsNullOrEmpty(Cliente)
                    ? clientes
                    : clientes.Where(c => c[1] == Cliente).ToList(); 

                foreach (var cliente in clientesFiltrados)
                {
                    dataGridViewDados.Rows.Add(cliente[0], cliente[1], cliente[2], cliente[3], cliente[4]);
                }
            }
            else
            {
                MessageBox.Show("Nenhum dado encontrado."); 
            }

        }

        private void FormDesconto_Load(object sender, EventArgs e)
        {

        }
    }
}

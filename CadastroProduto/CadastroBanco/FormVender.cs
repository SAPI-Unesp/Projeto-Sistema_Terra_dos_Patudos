using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CadastroBanco
{
    public partial class FormVender : Form
    {
        public decimal Qtd { get; private set; }
        public decimal QtdV { get; private set; }
        public string nomeComprador { get; private set; }
        public string telefoneComprador { get; private set;  }

        public string pagamento { get; private set; }

        public FormVender(decimal qtd, decimal preco)
        {
            InitializeComponent();
            QtdEstoque.Text = qtd.ToString();
            precoProd.Text = preco.ToString();
        }

        private void FormVender_Load(object sender, EventArgs e)
        {

        }

        private void Qt_TextChanged(object sender, EventArgs e)
        {

        }

        private void QtdVenda_TextChanged(object sender, EventArgs e)
        {

        }

        private void qtdVenda_ValueChanged(object sender, EventArgs e)
        {
            decimal qtdV = qtdVenda.Value;
            decimal precoT = qtdV * Convert.ToDecimal(precoProd.Text);

            precoTotal.Text = precoT.ToString();
           
        }

        private void btnVender_Click(object sender, EventArgs e)
        {
            decimal qtdE = Convert.ToDecimal(QtdEstoque.Text);
            decimal qtdV = qtdVenda.Value;
            

            if (qtdV <= qtdE)
            {
                Qtd = qtdE - qtdV;
                QtdV = qtdV;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            }

            if(cbNaoRealizado.Checked == true)
            {
                pagamento = "Pendente";
            }
            else
            {
                pagamento = "Realizado";
            }

        }

        private void NomeText_TextChanged(object sender, EventArgs e)
        {
            nomeComprador = NomeText.Text;
        }

        private void TelText_TextChanged(object sender, EventArgs e)
        {
            telefoneComprador = TelText.Text;
        }

        private void cbNaoRealizado_CheckedChanged(object sender, EventArgs e)
        {
            cbRealizado.Checked = false;
        }

        private void cbRealizado_CheckedChanged(object sender, EventArgs e)
        {
            cbNaoRealizado.Checked = false;
        }
    }

}


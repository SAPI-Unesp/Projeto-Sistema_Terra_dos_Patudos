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
        public decimal Quantidade { get; set; }
        public int max;

        public FormDesconto(int max)
        {
            this.max = max;
            InitializeComponent();
            valor.Value = 1;
        }


        private void dataGridViewDados_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void cbCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Quantidade = valor.Value;

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void FormDesconto_Load(object sender, EventArgs e)
        {

        }

        private void valor_ValueChanged(object sender, EventArgs e)
        {
            if (valor.Value > max)
            {
                valor.Value = max;
            }else if (valor.Value < 1)
            {
                valor.Value = 1;
            }
        }
    }
}

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

        public bool Cancelar { get; set; }

        public FormVender()
        {
            InitializeComponent();

            this.ControlBox = false;
            this.Text = "Exportando...";
            this.StartPosition = FormStartPosition.CenterScreen;

        }

        public void AttBar(int porcentagem, string status = null)
        {
            progressBar1.Value = porcentagem;
            if (status != null)
            {
                lblStatus.Text = status;
            }
        }



        private void FormVender_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }

}


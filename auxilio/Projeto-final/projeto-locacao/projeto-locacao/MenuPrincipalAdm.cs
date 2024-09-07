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
    public partial class MenuPrincipalAdm : Form
    {
        public static bool AdmB;
        public MenuPrincipalAdm()
        {
            InitializeComponent();
        }

        private void MenuPrincipalAdm_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            CadastrarFuncionario c1 = new CadastrarFuncionario();
            c1.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            RetirarFuncionario r1 = new RetirarFuncionario();
            r1.Show();
            this.Hide();
        }
    }
}

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
    public partial class Certeza : Form
    {
        public Certeza()
        {
            InitializeComponent();
        }
/* 

ESSA PARTE DE CERTEZA PODE SER USADA PARA ABSOLUTAMENTE TUDO, SO SERIA NECESSARIO CRIAR UM ATRIBUTO FALSE E COLOCAR ELE COMO TRUE NO AQUI
E DEPOIS DE USAR ELE COLOCAR FALSE DNV 

TEM QUE LEMBRAR DE RENOMEAR ESSA TELA PARA ----CERTEZA----

EX:

// NO MEU PRINCIPAL ----> Certeza.Certeza = False; --- para já deixar false desde o início
public static bool Certeza {get;set;}   --- NESSA TELA

NA TELA QUE VAI USAR:

MenuPrincipalX.X.Certeza();

DAI SERIA SÓ DAR CERTEZA E USAR ISSO NOS ---IFs---

if(Certeza.Certeza){
(ação X)

Certeza.Certeza = False; ---- Vai renovar o atributo para ter que dar certeza dnv, dá pra colocar em fucking qualquer lugar
}

*/


        private void button1_Click(object sender, EventArgs e)
        {
            /*Certeza = True;*/

            if (MenuPrincipalFuncionario.FuncionarioB)
            {
                MenuPrincipalFuncionario m1 = new MenuPrincipalFuncionario();
                m1.Show();
                this.Hide();
            }
            else
            {
                MenuPrincipalCliente m1 = new MenuPrincipalCliente();
                m1.Show();
                this.Hide();
            }
        }
    }
}

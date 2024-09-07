using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projeto_locacao
{
    public class Adm : Pessoa
    {
        public static int IdAdm { get; set; }

        public override void ChamarMenuPrincipal()
        {

            MenuPrincipalAdm m1 = new MenuPrincipalAdm();
            m1.Show();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projeto_locacao
{
    public class Cliente : Pessoa
    {
        public int IdCliente { get; set; }
        public string Status { get; set; }

        public override void ChamarMenuPrincipal()
        {
            MenuPrincipalCliente m1 = new MenuPrincipalCliente();
            m1.Show();
        }
    }
}

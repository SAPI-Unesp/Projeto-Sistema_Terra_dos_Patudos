using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projeto_locacao
{
    public class Funcionario : Pessoa
    {
        public int IdFuncionario { get; set; }
        public string Estatus { get; set; }
        public override void ChamarMenuPrincipal()
        {

            MenuPrincipalFuncionario m1 = new MenuPrincipalFuncionario();
            m1.Show();

        }
    }
}

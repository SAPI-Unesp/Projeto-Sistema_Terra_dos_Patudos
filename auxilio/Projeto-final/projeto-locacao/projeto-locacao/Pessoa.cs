using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projeto_locacao
{
    public abstract class Pessoa
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string Cpf { get; set; }
        public string Cep { get; set; }
        public string NumeroCasa { get; set; }
        public string Complemento { get; set; }
        public string Apelido { get; set; }

        public abstract void ChamarMenuPrincipal();
        public void Certeza()
        {
            Certeza c1 = new Certeza();
            c1.Show();
        }
    }
}

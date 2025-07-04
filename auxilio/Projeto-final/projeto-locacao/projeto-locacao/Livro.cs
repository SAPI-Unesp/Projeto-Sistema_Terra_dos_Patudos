using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projeto_locacao
{
    public class Livro
    {
        public static int IdLivro { get; set; }
        public static string Titulo { get; set; }
        public static string Autor { get; set; }
        public static string Editora { get; set; }
        public static string Data_chegada { get; set; }
        public static int Qtd_paginas { get; set; }
        public static string Valor_locacao { get; set; }
        public static int Fk_idFuncionario { get; set; }
        public static string Estatus { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaModelos
{
    public class Livro
    {
        public string Titulo { get; private set; }
        public Autor Autor { get; private set; }
        public Editora Editora { get; private set; }
        public Assunto Assunto { get; private set; }
        public Classificacao Classificacao { get; private set; }
    }
}

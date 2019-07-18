using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaModelos
{
    public class Exemplar
    {
        public string Registro { get; private set; }
        public int NumeroExemplar { get; private set; }
        public Livro Livro { get; private set; }
    }
}

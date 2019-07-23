using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaModelos
{
    public class Exemplar
    {
        public int ExemplarId { get; set; }
        public string Registro { get; internal set; }
        public int NumeroExemplar { get; internal set; }
        public Livro Livro { get; internal set; } //FK de Livro
    }
}

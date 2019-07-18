using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaModelos
{
    public class Pessoa
    {
        public int Id { get; set; }
        public string Nome { get; private set; }
        public string CPF { get; private set; }
        public Endereco Endereco { get; private set; }
    }
}

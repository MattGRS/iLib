using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaModelos
{
    public class Emprestimo
    {
        public DateTime DataEmprestimo { get; private set; }
        public DateTime DataDevolucao { get; private set; }
    }
}

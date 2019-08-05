using BibliotecaDominio.ObjetosValor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteApp
{
    class Program
    {
        static void Main(string[] args)
        {
            CPF teste = new CPF("043.803.879-76");

            //CPF teste2 = new CPF("254-863-654-97");

            //CPF teste3 = new CPF("586.789.745-25");

            Console.WriteLine(teste.Cpf);

            //Console.WriteLine(teste2.Cpf);

            //Console.WriteLine(teste3.Cpf);
        }
    }
}

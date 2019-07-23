using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaModelos
{
    public class Pessoa
    {
        public int PessoaId { get; set; }
        public string Nome { get; internal set; }
        public string CPF { get; internal set; }
        public string RG { get; internal set; }
        public DateTime DataDeNascimento { get; internal set; }
        public int Idade { get; internal set; }
        public Endereco Endereco { get; internal set; } //FK de Endereco
        public string Profissao { get; internal set; }
        public string Telefone { get; internal set; }
    }
}

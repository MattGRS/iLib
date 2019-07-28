using BibliotecaDominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaDominio
{
    public class Pessoa
    {
        public int PessoaId { get; set; }
        public string Nome { get; internal set; }
        public CPF CPF { get; internal set; } //verificar a validação de cpf
        public string RG { get; internal set; }
        public DateTime DataDeNascimento { get; internal set; }
        public int Idade { get; internal set; }
        public Endereco Endereco { get; internal set; } //FK de Endereco
        public string Profissao { get; internal set; }
        public string Telefone { get; internal set; }
        public string Email { get; internal set; }
        public Usuario Usuario { get; internal set; }
    }
}

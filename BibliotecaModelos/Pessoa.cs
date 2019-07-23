using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaModelos
{
    public class Pessoa
    {
        public int PessoaId { get; set; }
        [Required, StringLength(30)]
        public string Nome { get; internal set; }
        [Required, RegularExpression("[0-9]{11}")]
        public string CPF { get; internal set; } //verificar a validação de cpf
        public string RG { get; internal set; }
        public DateTime DataDeNascimento { get; internal set; }
        public int Idade { get; internal set; }
        public Endereco Endereco { get; internal set; } //FK de Endereco
        public string Profissao { get; internal set; }
        public string Telefone { get; internal set; }
        public string Email { get; internal set; }
    }
}

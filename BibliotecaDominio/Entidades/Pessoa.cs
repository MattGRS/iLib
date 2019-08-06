using BibliotecaDominio.Entidades.ObjetosValor;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BibliotecaDominio.Entidades
{
    public class Pessoa
    { 
        public int PessoaId { get; set; }
        [Required, MaxLength(50)]
        public string Nome { get; internal set; }
        [Required]
        public CPF CPF { get; internal set; } //verificar a validação de cpf
        [Required]
        public string RG { get; internal set; }
        [Required]
        public DateTime DataDeNascimento { get; internal set; }
        public int Idade { get; internal set; }
        [Required]
        public virtual Endereco Endereco { get; internal set; } //FK de Endereco
        public string Profissao { get; internal set; }
        public string Telefone { get; internal set; }
        [Required]
        public string Email { get; internal set; }
        [Required]
        public virtual DadosLogin Login { get; set; }
        public virtual IEnumerable<Emprestimo> Emprestimo { get; set; }
    }
}

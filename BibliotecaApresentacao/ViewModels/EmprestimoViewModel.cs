using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BibliotecaApresentacao.ViewModels
{
    public class EmprestimoViewModel
    {
        [Key]
        public int EmprestimoId { get; set; }

        public DateTime DataEmprestimo { get; internal set; }

        public DateTime DataDevolucao { get; internal set; }

        [Required(ErrorMessage = "É necessário um Exemplar para realizar o empréstimo.")]
        public virtual ExemplarLivroViewModel ExemplarLivro { get; set; }

        [Required(ErrorMessage = "É necessário uma Pessoa para realizar o empréstimo.")]
        public virtual PessoaViewModel Pessoa { get; set; }
    }
}
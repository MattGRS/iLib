using System;
using System.ComponentModel.DataAnnotations;

namespace BibliotecaApresentacao.ViewModels
{
    public class EmprestimoViewModel
    {
        [Key]
        public int EmprestimoId { get; set; }

        public DateTime DataEmprestimo { get; set; }

        public DateTime DataDevolucaoPrevista { get; internal set; }

        public DateTime DataDevolucaoRealizada { get; internal set; }

        [Required(ErrorMessage = "É necessário um Exemplar para realizar o empréstimo.")]
        public int ExemplarLivroId { get; set; }

        public virtual ExemplarLivroViewModel ExemplarLivro { get; set; }

        [Required(ErrorMessage = "É necessário uma Pessoa para realizar o empréstimo.")]
        public int PessoaId { get; set; }

        public virtual PessoaViewModel Pessoa { get; set; }
    }
}
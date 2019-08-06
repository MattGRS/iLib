using System;
using System.ComponentModel.DataAnnotations;

namespace BibliotecaDominio.Entidades
{
    public class Emprestimo
    {
        public int EmprestimoId { get; set; }
        public DateTime DataEmprestimo { get; internal set; }
        public DateTime DataDevolucao { get; internal set; }
        [Required]
        public virtual ExemplarLivro ExemplarLivro { get; set; }
        [Required]
        public virtual Pessoa Pessoa { get; set; }

    }
}


using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BibliotecaDominio.Entidades
{
    public class ExemplarLivro
    {
        public int ExemplarLivroId { get; set; }

        [Required, MaxLength(100)]
        public string Registro { get; internal set; }

        public int NumeroExemplar { get; internal set; }

        public int LivroId { get; set; }

        public virtual Livro Livro { get; internal set; } //FK de Livro

        public virtual IEnumerable<Emprestimo> Emprestimo { get; set; }
    }
}

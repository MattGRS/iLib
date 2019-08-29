
using BibliotecaDominio.Entidades.ObjetosValor;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BibliotecaDominio.Entidades
{
    public class ExemplarLivro
    {
        [Key]
        public int ExemplarLivroId { get; set; }

        [Required, MaxLength(100)]
        public string Registro { get; internal set; }

        public int NumeroExemplar { get; internal set; }
        [Required]
        public int LivroId { get; set; }

        public StatusExemplarLivro Status { get; internal set; }

        public virtual Livro Livro { get; internal set; } //FK de Livro

        public virtual IEnumerable<Emprestimo> Emprestimo { get; set; }

        public ExemplarLivro(int exemplarLivroId, string registro, int numeroExemplar, int livroId)
        {
            ExemplarLivroId = exemplarLivroId;
            Registro = registro;
            NumeroExemplar = numeroExemplar;
            LivroId = livroId;
        }

        public void MarcaExemplarLivroComoDisponivel()
        {
            Status = StatusExemplarLivro.Disponivel;
        }

        public void MarcaExemplarLivroComoEmprestado()
        {
            Status = StatusExemplarLivro.Indisponivel;
        }

    }
}

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BibliotecaDominio.Entidades
{
    public class Emprestimo
    {
        public int EmprestimoId { get; set; }

        public DateTime DataEmprestimo { get; internal set; }

        public DateTime DataDevolucaoPrevista { get; internal set; }

        public DateTime DataDecolucaoRealizada { get; internal set; }

        public int ExemplarLivroId { get; set; }

        public int PessoaId { get; set; }

        public virtual ExemplarLivro ExemplarLivro { get; set; }

        public virtual Pessoa Pessoa { get; set; }

        public void Devolver()
        {
            DataDecolucaoRealizada = DateTime.Now;
        }
    }
}

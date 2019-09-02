using BibliotecaDominio.Entidades.ObjetosValor;
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

        public DateTime DataDevolucaoRealizada { get; internal set; }

        public int ExemplarLivroId { get; set; }

        public int PessoaId { get; set; }
        public StatusEmprestimo Status { get; internal set; }

        public virtual ExemplarLivro ExemplarLivro { get; set; }

        public virtual Pessoa Pessoa { get; set; }

        public void Devolver()
        {
            DataDevolucaoRealizada = DateTime.Now;
            Status = StatusEmprestimo.Finalizado;
        }

        public void Emprestar()
        {
            DataEmprestimo = DateTime.Now;
            DataDevolucaoPrevista = DateTime.Now.AddDays(7);
            Status = StatusEmprestimo.Aberto;

            DataDevolucaoPrevistaIsOnWeekend();
        }

        private void DataDevolucaoPrevistaIsOnWeekend()
        {
            DataDevolucaoPrevistaIsOnSunday();
            DataDevolucaoPrevistaIsOnSaturday();
        }

        private void DataDevolucaoPrevistaIsOnSaturday()
        {
            var dayOfWeek = DataDevolucaoPrevista.DayOfWeek;
            if (dayOfWeek == DayOfWeek.Saturday)
            {
                DataDevolucaoPrevista.AddDays(1);
            }
        }

        private void DataDevolucaoPrevistaIsOnSunday()
        {
            var dayOfWeek = DataDevolucaoPrevista.DayOfWeek;

            if (dayOfWeek == DayOfWeek.Sunday)
            {
                DataDevolucaoPrevista.AddDays(2);
            }
        }
    }
}

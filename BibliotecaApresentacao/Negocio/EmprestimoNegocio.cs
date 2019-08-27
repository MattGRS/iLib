using System;
using BibliotecaApresentacao.ViewModels;

namespace BibliotecaApresentacao.Negocio
{
    public class EmprestimoNegocio
    {
        public void DefineDataDevolucaoPrevista(EmprestimoViewModel emprestimoViewModel)
        {
            emprestimoViewModel.DataEmprestimo = DateTime.Now;
            emprestimoViewModel.DataDevolucaoPrevista = DateTime.Now.AddDays(7);

            DataDevolucaoPrevistaIsOnWeekend(emprestimoViewModel);
        }

        public void DataDevolucaoPrevistaIsOnWeekend(EmprestimoViewModel emprestimoViewModel)
        {
            DataDevolucaoPrevistaIsOnSunday(emprestimoViewModel);
            DataDevolucaoPrevistaIsOnSaturday(emprestimoViewModel);
        }

        private void DataDevolucaoPrevistaIsOnSaturday(EmprestimoViewModel emprestimoViewModel)
        {
            var dayOfWeek = emprestimoViewModel.DataDevolucaoPrevista.DayOfWeek;
            if (dayOfWeek == DayOfWeek.Saturday)
            {
                emprestimoViewModel.DataDevolucaoPrevista.AddDays(1);
            }
        }

        private void DataDevolucaoPrevistaIsOnSunday(EmprestimoViewModel emprestimoViewModel)
        {
            var dayOfWeek = emprestimoViewModel.DataDevolucaoPrevista.DayOfWeek;

            if (dayOfWeek == DayOfWeek.Sunday)
            {
                emprestimoViewModel.DataDevolucaoPrevista.AddDays(2);
            }
        }

        public void DefineDataDevolucaoRealizada(EmprestimoViewModel emprestimoViewModel)
        {
            emprestimoViewModel.DataDevolucaoRealizada = DateTime.Now;
        }
    }
}

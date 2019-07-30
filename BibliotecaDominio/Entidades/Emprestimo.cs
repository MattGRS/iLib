using System;


namespace BibliotecaDominio.Entidades
{
    public class Emprestimo
    {
        //Qual relação utilizar??
        public DateTime DataEmprestimo { get; internal set; }
        public DateTime DataDevolucao { get; internal set; }

    }
}

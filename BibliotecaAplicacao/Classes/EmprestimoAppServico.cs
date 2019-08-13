using BibliotecaAplicacao.Interfaces;
using BibliotecaDominio.Entidades;
using BibliotecaDominio.Interfaces.Servicos;

namespace BibliotecaAplicacao.Classes
{
    public class EmprestimoAppServico : BibliotecaAppServico<Emprestimo>, IEmprestimoAppServico
    {
        private readonly IEmprestimoServico _emprestimoServico;

        public EmprestimoAppServico(IEmprestimoServico emprestimoServico) : base(emprestimoServico)
        {
            _emprestimoServico = emprestimoServico;
        }

        public new bool Remover(Emprestimo emprestimo)
        {
            return _emprestimoServico.Remover(emprestimo);
        }
    }
}

using BibliotecaDominio.Entidades;
using BibliotecaDominio.Interfaces.Repositorio;
using BibliotecaDominio.Interfaces.Servicos;

namespace BibliotecaDominio.Servicos
{
    public class EmprestimoServico : BibliotecaServicoBase<Emprestimo>, IEmprestimoServico
    {
        private readonly IEmprestimoRepositorio _emprestimoRepositorio;

        public EmprestimoServico(IEmprestimoRepositorio emprestimoRepositorio) : base(emprestimoRepositorio)
        {
            _emprestimoRepositorio = emprestimoRepositorio;
        }

        public new bool Remover(Emprestimo emprestimo)
        {
            return _emprestimoRepositorio.Remover(emprestimo);
        }
    }
}

using BibliotecaDominio.Entidades;

namespace BibliotecaDominio.Interfaces.Servicos
{
    public interface IEmprestimoServico : IBibliotecaServicoBase<Emprestimo>
    {
        new bool Remover(Emprestimo emprestimo);

    }
}

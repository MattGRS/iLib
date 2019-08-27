using BibliotecaDominio.Entidades;

namespace BibliotecaDominio.Interfaces.Repositorio
{
    public interface IEmprestimoRepositorio : IBibliotecaRepositorioBase<Emprestimo>
    {
        new bool Remover(Emprestimo emprestimo);

        void Devolver(int id);
    }
}

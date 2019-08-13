using BibliotecaDominio.Entidades;

namespace BibliotecaDominio.Interfaces.Repositorio
{
    public interface ILivroRepositorio : IBibliotecaRepositorioBase<Livro>
    {
        new bool Remover(Livro livro);
    }
}

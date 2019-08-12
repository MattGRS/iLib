using BibliotecaDominio.Entidades.ObjetosValor;

namespace BibliotecaDominio.Interfaces.Repositorio
{
    public interface IEditoraRepositorio : IBibliotecaRepositorioBase<Editora>
    {
        new bool Remover(Editora editora);
    }
}

using BibliotecaDominio.Entidades.ObjetosValor;

namespace BibliotecaDominio.Interfaces.Repositorio
{
    public interface IPaisRepositorio : IBibliotecaRepositorioBase<Pais>
    {
        new bool Remover(Pais pais);
    }
}

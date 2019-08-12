using BibliotecaDominio.Entidades.ObjetosValor;

namespace BibliotecaDominio.Interfaces.Repositorio
{
    public interface IEstadoRepositorio : IBibliotecaRepositorioBase<Estado>
    {
        new bool Remover(Estado estado);
    }
}

using BibliotecaDominio.Entidades.ObjetosValor;

namespace BibliotecaDominio.Interfaces.Repositorio
{
    public interface ILocalizacaoRepositorio : IBibliotecaRepositorioBase<Localizacao>
    {
        new bool Remover(Localizacao localizacao);
    }
}

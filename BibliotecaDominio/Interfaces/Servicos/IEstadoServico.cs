using BibliotecaDominio.Entidades.ObjetosValor;

namespace BibliotecaDominio.Interfaces.Servicos
{
    public interface IEstadoServico : IBibliotecaServicoBase<Estado>
    {
        new bool Remover(Estado estado);
    }
}

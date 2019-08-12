using BibliotecaDominio.Entidades.ObjetosValor;

namespace BibliotecaAplicacao.Interfaces
{
    public interface IEstadoAppServico : IBibliotecaAppServicoBase<Estado>
    {
        new bool Remover(Estado estado);
    }
}

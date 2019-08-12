using BibliotecaDominio.Entidades.ObjetosValor;

namespace BibliotecaDominio.Interfaces.Servicos
{
    public interface ILocalizacaoServico : IBibliotecaServicoBase<Localizacao>
    {
        new bool Remover(Localizacao localizacao);
    }
}

using BibliotecaDominio.Entidades.ObjetosValor;

namespace BibliotecaAplicacao.Interfaces
{
    public interface ILocalizacaoAppServico : IBibliotecaAppServicoBase<Localizacao>
    {
        new bool Remover(Localizacao localizacao);
    }
}

using BibliotecaDominio.Entidades.ObjetosValor;
using BibliotecaDominio.Interfaces.Repositorio;
using BibliotecaDominio.Interfaces.Servicos;

namespace BibliotecaDominio.Servicos
{
    public class LocalizacaoServico : BibliotecaServicoBase<Localizacao>, ILocalizacaoServico
    {
        private readonly ILocalizacaoRepositorio _localizacaoRepositorio;

        public LocalizacaoServico(ILocalizacaoRepositorio localizacaoRepositorio) : base(localizacaoRepositorio)
        {
            _localizacaoRepositorio = localizacaoRepositorio;
        }

        public new bool Remover(Localizacao localizacao)
        {
            return _localizacaoRepositorio.Remover(localizacao);
        }
    }
}

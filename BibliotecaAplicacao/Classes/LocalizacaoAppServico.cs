using BibliotecaAplicacao.Interfaces;
using BibliotecaDominio.Entidades.ObjetosValor;
using BibliotecaDominio.Interfaces.Servicos;

namespace BibliotecaAplicacao.Classes
{
    public class LocalizacaoAppServico : BibliotecaAppServico<Localizacao>, ILocalizacaoAppServico
    {
        private readonly ILocalizacaoServico _localizacaoServico;

        public LocalizacaoAppServico(ILocalizacaoServico localizacaoServico) : base(localizacaoServico)
        {
            _localizacaoServico = localizacaoServico;
        }

        public new bool Remover(Localizacao localizacao)
        {
            return _localizacaoServico.Remover(localizacao);
        }
    }
}

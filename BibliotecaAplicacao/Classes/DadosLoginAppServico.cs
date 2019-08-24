using BibliotecaAplicacao.Interfaces;
using BibliotecaDominio.Entidades.ObjetosValor;
using BibliotecaDominio.Interfaces.Servicos;

namespace BibliotecaAplicacao.Classes
{
    public class DadosLoginAppServico : BibliotecaAppServico<DadosLogin>, IDadosLoginAppServico
    {
        private readonly IDadosLoginServico _dadosLoginServico;

        public DadosLoginAppServico(IDadosLoginServico dadosLoginServico) : base(dadosLoginServico)
        {
            _dadosLoginServico = dadosLoginServico;
        }

        public new bool Remover(DadosLogin dadosLogin)
        {
            return _dadosLoginServico.Remover(dadosLogin);
        }

        public DadosLogin SearchUser(string login, string senha)
        {
            return _dadosLoginServico.SearchUser(login, senha);
        }
    }
}

using BibliotecaDominio.Entidades.ObjetosValor;
using BibliotecaDominio.Interfaces.Repositorio;
using BibliotecaDominio.Interfaces.Servicos;

namespace BibliotecaDominio.Servicos
{
    public class DadosLoginServico : BibliotecaServicoBase<DadosLogin>, IDadosLoginServico
    {
        private readonly IDadosLoginRepositorio _dadosLoginRepositorio;

        public DadosLoginServico(IDadosLoginRepositorio dadosLoginRepositorio) : base(dadosLoginRepositorio)
        {
            _dadosLoginRepositorio = dadosLoginRepositorio;
        }

        public new bool Remover(DadosLogin dadosLogin)
        {
            return _dadosLoginRepositorio.Remover(dadosLogin);
        }

        public DadosLogin SearchUser(string login, string senha)
        {
            return _dadosLoginRepositorio.SearchUser(login, senha);
        }
    }
}

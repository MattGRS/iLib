using BibliotecaAplicacao.Interfaces;
using BibliotecaDominio.Entidades.ObjetosValor;
using BibliotecaDominio.Interfaces.Servicos;

namespace BibliotecaAplicacao.Classes
{
    public class EstadoAppServico : BibliotecaAppServico<Estado>, IEstadoAppServico
    {
        private readonly IEstadoServico _estadoServico;

        public EstadoAppServico(IEstadoServico estadoServico) : base(estadoServico)
        {
            _estadoServico = estadoServico;
        }

        public new bool Remover(Estado estado)
        {
            return _estadoServico.Remover(estado);
        }
    }
}

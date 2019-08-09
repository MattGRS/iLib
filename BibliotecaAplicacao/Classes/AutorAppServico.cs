using BibliotecaAplicacao.Interfaces;
using BibliotecaDominio.Entidades.ObjetosValor;
using BibliotecaDominio.Interfaces.Servicos;

namespace BibliotecaAplicacao.Classes
{
    public class AutorAppServico : BibliotecaAppServico<Autor>, IAutorAppServico
    {
        private readonly IAutorServico _autorServico;

        public AutorAppServico(IAutorServico autorServico) : base(autorServico)
        {
            _autorServico = autorServico;
        }

        public new bool Remover(Autor autor)
        {
            return _autorServico.Remover(autor);
        }
    }
}

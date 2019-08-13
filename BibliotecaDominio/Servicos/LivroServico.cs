using BibliotecaDominio.Entidades;
using BibliotecaDominio.Interfaces.Repositorio;
using BibliotecaDominio.Interfaces.Servicos;

namespace BibliotecaDominio.Servicos
{
    public class LivroServico : BibliotecaServicoBase<Livro>, ILivroServico
    {
        private readonly ILivroRepositorio _livroRepositorio;

        public LivroServico(ILivroRepositorio livroRepositorio) : base(livroRepositorio)
        {
            _livroRepositorio = livroRepositorio;
        }

        public new bool Remover(Livro livro)
        {
            return _livroRepositorio.Remover(livro);
        }
    }
}

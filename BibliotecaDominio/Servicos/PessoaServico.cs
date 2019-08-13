using BibliotecaDominio.Entidades;
using BibliotecaDominio.Interfaces.Repositorio;
using BibliotecaDominio.Interfaces.Servicos;

namespace BibliotecaDominio.Servicos
{
    public class PessoaServico : BibliotecaServicoBase<Pessoa>, IPessoaServico
    {
        private readonly IPessoaRepositorio _pessoaRepositorio;

        public PessoaServico(IPessoaRepositorio pessoaRepositorio) : base(pessoaRepositorio)
        {
            _pessoaRepositorio = pessoaRepositorio;
        }

        public new bool Remover(Pessoa pessoa)
        {
            return _pessoaRepositorio.Remover(pessoa);
        }
    }
}

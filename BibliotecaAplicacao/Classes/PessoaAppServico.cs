using BibliotecaAplicacao.Interfaces;
using BibliotecaDominio.Entidades;
using BibliotecaDominio.Interfaces.Servicos;

namespace BibliotecaAplicacao.Classes
{
    public class PessoaAppServico : BibliotecaAppServico<Pessoa>, IPessoaAppServico
    {
        private readonly IPessoaServico _pessoaServico;

        public PessoaAppServico(IPessoaServico pessoaServico) : base(pessoaServico)
        {
            _pessoaServico = pessoaServico;
        }

        public new bool Remover(Pessoa pessoa)
        {
            return _pessoaServico.Remover(pessoa);
        }
    }
}

using BibliotecaAplicacao.Interfaces;
using BibliotecaDominio.Entidades;
using BibliotecaDominio.Interfaces.Servicos;

namespace BibliotecaAplicacao.Classes
{
    public class EnderecoAppServico : BibliotecaAppServico<Endereco>, IEnderecoAppServico
    {
        private readonly IEnderecoServico _enderecoServico;

        public EnderecoAppServico(IEnderecoServico enderecoServico) : base(enderecoServico)
        {
            _enderecoServico = enderecoServico;
        }

        public new bool Remover(Endereco endereco)
        {
            return _enderecoServico.Remover(endereco);
        }
    }
}

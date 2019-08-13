using BibliotecaDominio.Entidades;
using BibliotecaDominio.Interfaces.Repositorio;
using BibliotecaDominio.Interfaces.Servicos;

namespace BibliotecaDominio.Servicos
{
    public class EnderecoServico : BibliotecaServicoBase<Endereco>, IEnderecoServico
    {
        private readonly IEnderecoRepositorio _enderecoRepositorio;

        public EnderecoServico(IEnderecoRepositorio enderecoRepositorio) : base(enderecoRepositorio)
        {
            _enderecoRepositorio = enderecoRepositorio;
        }

        public new bool Remover(Endereco endereco)
        {
            return _enderecoRepositorio.Remover(endereco);
        }
    }
}

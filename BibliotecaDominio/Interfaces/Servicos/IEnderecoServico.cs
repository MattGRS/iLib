using BibliotecaDominio.Entidades;

namespace BibliotecaDominio.Interfaces.Servicos
{
    public interface IEnderecoServico : IBibliotecaServicoBase<Endereco>
    {
        new bool Remover(Endereco endereco);
    }
}

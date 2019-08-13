using BibliotecaDominio.Entidades;

namespace BibliotecaAplicacao.Interfaces
{
    public interface IEnderecoAppServico : IBibliotecaAppServicoBase<Endereco>
    {
        new bool Remover(Endereco endereco);
    }
}

using BibliotecaDominio.Entidades;

namespace BibliotecaAplicacao.Interfaces
{
    public interface IPessoaAppServico : IBibliotecaAppServicoBase<Pessoa>
    {
        new bool Remover(Pessoa pessoa);
    }
}

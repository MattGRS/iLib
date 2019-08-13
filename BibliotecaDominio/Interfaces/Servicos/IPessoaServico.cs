using BibliotecaDominio.Entidades;

namespace BibliotecaDominio.Interfaces.Servicos
{
    public interface IPessoaServico : IBibliotecaServicoBase<Pessoa>
    {
        new bool Remover(Pessoa pessoa);
    }
}

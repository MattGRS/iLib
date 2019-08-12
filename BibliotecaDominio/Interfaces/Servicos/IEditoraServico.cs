using BibliotecaDominio.Entidades.ObjetosValor;

namespace BibliotecaDominio.Interfaces.Servicos
{
    public interface IEditoraServico : IBibliotecaServicoBase<Editora>
    {
        new bool Remover(Editora editora);
    }
}

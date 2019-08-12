using BibliotecaDominio.Entidades.ObjetosValor;

namespace BibliotecaAplicacao.Interfaces
{
    public interface IEditoraAppServico : IBibliotecaAppServicoBase<Editora>
    {
        new bool Remover(Editora editora);
    }
}

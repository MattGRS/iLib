using BibliotecaDominio.Entidades.ObjetosValor;
using BibliotecaDominio.Interfaces.Repositorio;
using BibliotecaDominio.Interfaces.Servicos;

namespace BibliotecaDominio.Servicos
{
    public class EditoraServico : BibliotecaServicoBase<Editora>, IEditoraServico
    {
        private readonly IEditoraRepositorio _editoraRepositorio;

        public EditoraServico(IEditoraRepositorio editoraRepositorio) : base(editoraRepositorio)
        {
            _editoraRepositorio = editoraRepositorio;
        }

        public new bool Remover(Editora editora)
        {
            return _editoraRepositorio.Remover(editora);
        }
    }
}

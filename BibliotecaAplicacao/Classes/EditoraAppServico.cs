using BibliotecaAplicacao.Interfaces;
using BibliotecaDominio.Entidades.ObjetosValor;
using BibliotecaDominio.Interfaces.Servicos;

namespace BibliotecaAplicacao.Classes
{
    public class EditoraAppServico : BibliotecaAppServico<Editora>, IEditoraAppServico
    {
        private readonly IEditoraServico _editoraServico;

        public EditoraAppServico(IEditoraServico editoraServico) : base(editoraServico)
        {
            _editoraServico = editoraServico;
        }

        public new bool Remover(Editora editora)
        {
            return _editoraServico.Remover(editora);
        }
    }
}

using System.Collections.Generic;

namespace BibliotecaDominio
{
    public class Editora
    {
        public int EditoraId { get; set; }
        public string NomeEditora { get; internal set; }
        public Endereco Endereco { get; internal set; } //FK de endereços
        public IEnumerable<Livro> Livros { get; internal set; } //relação um para muitos (uma editora - muitos livros)
    }
}
using System.Collections.Generic;

namespace BibliotecaDominio
{
    public class Autor
    {
        public int AutorId { get; set; }
        public string NomeAutor { get; internal set; }
        public IEnumerable<Livro> Livros { get; internal set; } //relação um para muitos (um autos - muitos livros)
    }
}
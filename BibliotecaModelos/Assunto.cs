using System.Collections.Generic;

namespace BibliotecaModelos
{
    public class Assunto
    {
        public int AssuntoId { get; set; }
        public string AssuntoObra { get; internal set; }
        public IList<Livro> Livros { get; internal set; } //Relação um para muitos (um assunto - muitos livros)
    }
}
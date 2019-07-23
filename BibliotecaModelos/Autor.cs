using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BibliotecaModelos
{
    public class Autor
    {
        public int AutorId { get; set; }
        [StringLength(40), Required]
        public string NomeAutor { get; internal set; }
        public IList<Livro> Livros { get; internal set; } //relação um para muitos (um autos - muitos livros)
    }
}
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BibliotecaModelos
{
    public class Assunto
    {
        public int AssuntoId { get; set; }
        [StringLength(30), Required]
        public string AssuntoObra { get; internal set; }
        public IList<Livro> Livros { get; internal set; } //Relação um para muitos (um assunto - muitos livros)
    }
}
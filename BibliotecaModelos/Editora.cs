using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BibliotecaModelos
{
    public class Editora
    {
        public int EditoraId { get; set; }
        [StringLength(40), Required]
        public string NomeEditora { get; internal set; }
        public Endereco Endereco { get; internal set; } //FK de endereços
        public IList<Livro> Livros { get; internal set; } //relação um para muitos (uma editora - muitos livros)
    }
}
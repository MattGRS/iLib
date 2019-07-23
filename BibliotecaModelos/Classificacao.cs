using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BibliotecaModelos
{
    public class Classificacao
    {
        public int ClassificacaoId { get; set; }
        [StringLength(20), Required]
        public string ClassificacaoObra { get; internal set; }
        public IList<Livro> Livros { get; internal set; } //relação um para muitos (uma classificação - muitos livros)
    }
}
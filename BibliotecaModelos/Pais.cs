using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BibliotecaModelos
{
    public class Pais
    {
        public int PaisId { get; set; }
        [Required, StringLength(15)]
        public string NomePais { get; internal set; }
        public IList<Estado> Estados { get; internal set; } //relação um para muitos (um pais - muitos estados)
    }
}
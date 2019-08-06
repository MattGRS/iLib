using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BibliotecaDominio.ObjetosValor
{
    public class Pais
    {
        public int PaisId { get; set; }
        [Required, MaxLength(50)]
        public string NomePais { get; internal set; }
        public virtual IEnumerable<Estado> Estados { get; internal set; } //relação um para muitos (um pais - muitos estados)
    }
}
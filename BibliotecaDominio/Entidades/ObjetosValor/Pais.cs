using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BibliotecaDominio.Entidades.ObjetosValor
{
    public class Pais
    {
        public int PaisId { get; set; }

        [Required, MaxLength(100)]
        public string NomePais { get; internal set; }

        public virtual IEnumerable<Estado> Estados { get; internal set; } //relação um para muitos (um pais - muitos estados)
    }
}
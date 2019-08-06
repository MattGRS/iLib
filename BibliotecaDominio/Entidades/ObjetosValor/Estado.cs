using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BibliotecaDominio.ObjetosValor
{
    public class Estado
    {
        public int EstadoId { get; set; }
        [Required, MaxLength(50)]
        public string NomeEstado { get; internal set; }
        [Required]
        public virtual Pais Pais { get; internal set; } //FK de Pais
        public virtual IEnumerable<Municipio> Municipios { get; internal set; } //relação muitos para um (um estado - muitos municipios)
    }
}

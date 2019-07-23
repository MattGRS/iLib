using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaModelos
{
    public class Estado
    {
        public int EstadoId { get; set; }
        [Required, StringLength(15)]
        public string NomeEstado { get; internal set; }
        public Pais Pais { get; internal set; } //FK de Pais
        public IList<Municipio> Municipios { get; internal set; } //relação muitos para um (um estado - muitos municipios)
    }
}

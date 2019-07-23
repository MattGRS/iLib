using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaModelos
{
    public class Estado
    {
        public int EstadoId { get; set; }
        public string NomeEstado { get; internal set; }
        public Pais Pais { get; internal set; } //FK de Pais
        public IList<Municipio> Municipios { get; internal set; } //relação muitos para um (um estado - muitos municipios)
    }
}

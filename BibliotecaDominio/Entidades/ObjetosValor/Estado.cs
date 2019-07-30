using System.Collections.Generic;

namespace BibliotecaDominio.ObjetosValor
{
    public class Estado
    {
        public int EstadoId { get; set; }
        public string NomeEstado { get; internal set; }
        public Pais Pais { get; internal set; } //FK de Pais
        public IEnumerable<Municipio> Municipios { get; internal set; } //relação muitos para um (um estado - muitos municipios)
    }
}

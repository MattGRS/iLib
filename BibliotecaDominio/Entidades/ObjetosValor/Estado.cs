using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BibliotecaDominio.Entidades.ObjetosValor
{
    public class Estado
    {
        public int EstadoId { get; set; }

        [Required, MaxLength(100)]
        public string NomeEstado { get; internal set; }

        public int PaisId { get; set; }

        public virtual Pais Pais { get; internal set; } //FK de Pais

        public virtual IEnumerable<Municipio> Municipios { get; internal set; } //relação muitos para um (um estado - muitos municipios)

        public Estado()
        {

        }

        public Estado(int estadoId, string estadoNome, int paisId)
        {
            EstadoId = estadoId;
            NomeEstado = estadoNome;
            PaisId = paisId;
        }
    }
}

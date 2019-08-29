using BibliotecaDominio.Entidades;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BibliotecaDominio.Entidades.ObjetosValor
{
    public class Municipio
    {
        public int MunicipioId { get; set; }

        [Required, MaxLength(100)]
        public string NomeMunicipio { get;  internal set; }

        public int EstadoId { get; set; }

        public virtual Estado Estado { get; internal set; } //FK de Estado

        public virtual IEnumerable<Endereco> Enderecos { get; internal set; } //relação um para muitos (um municipio - muitos enderecos)

        public Municipio(int municipioId, string nomeMunicipio, int estadoId)
        {
            MunicipioId = municipioId;
            NomeMunicipio = nomeMunicipio;
            EstadoId = estadoId;
        }
    }
}
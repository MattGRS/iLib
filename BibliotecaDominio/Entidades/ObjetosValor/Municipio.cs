using BibliotecaDominio.Entidades;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BibliotecaDominio.Entidades.ObjetosValor
{
    public class Municipio
    {
        public int MunicipioId { get; set; }
        [Required, MaxLength(50)]
        public string NomeMunicipio { get;  internal set; }
        [Required]
        public virtual Estado Estado { get; internal set; } //FK de Estado
        public virtual IEnumerable<Endereco> Enderecos { get; internal set; } //relação um para muitos (um municipio - muitos enderecos)
    }
}
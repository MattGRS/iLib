using BibliotecaDominio.ObjetosValor;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BibliotecaDominio.Entidades
{
    public class Endereco
    {
        public int EnderecoId { get; set; }
        [Required]
        public string CEP { get; internal set; } //Ver como fazer a verificação pelos correios;
        [Required, MaxLength(70)]
        public string Logradouro { get; internal set; }
        [Required, MaxLength(50)]
        public string Bairro { get; internal set; }
        public int NumeroResidencial { get; internal set; }
        public string Complemento { get; internal set; }
        [Required]
        public virtual Municipio Municipio { get; internal set; } //FK de Municipio
        public virtual IEnumerable<Pessoa> Pessoas { get; internal set; } //relação um para muitos (um endereço - muitas pessoas)
        public virtual IEnumerable<Editora> Editoras { get; internal set; } //relação um para muitos (um endereço - muitas editoras)

    }
}
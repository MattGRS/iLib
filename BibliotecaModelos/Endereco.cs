using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BibliotecaModelos
{
    public class Endereco
    {
        public int EnderecoId { get; set; }
        [RegularExpression("[0-9]{8}"), Required]
        public string CEP { get; internal set; } //Ver como fazer a verificação pelos correios;
        [StringLength(50), Required]
        public string Logradouro { get; internal set; }
        public string Bairro { get; internal set; }
        [Required]
        public int NumeroResidencial { get; internal set; }
        public string Complemento { get; internal set; }
        [Required]
        public Municipio Municipio { get; private set; } //FK de Municipio
        public IList<Pessoa> Pessoas { get; internal set; } //relação um para muitos (um endereço - muitas pessoas)
        public IList<Editora> Editoras { get; internal set; } //relação um para muitos (um endereço - muitas editoras)

    }
}
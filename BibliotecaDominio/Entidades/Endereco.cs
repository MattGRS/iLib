using BibliotecaDominio.Entidades.ObjetosValor;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BibliotecaDominio.Entidades
{
    public class Endereco
    {
        public int EnderecoId { get; set; }

        [Required]
        public string CEP { get; internal set; } //Ver como fazer a verificação pelos correios;

        [Required, MaxLength(100)]
        public string Logradouro { get; internal set; }

        [Required, MaxLength(100)]
        public string Bairro { get; internal set; }

        public int NumeroResidencial { get; internal set; }

        public string Complemento { get; internal set; }

        public int MunicipioId { get; set; }

        public virtual Municipio Municipio { get; internal set; } //FK de Municipio

        public virtual IEnumerable<Pessoa> Pessoas { get; internal set; } //relação um para muitos (um endereço - muitas pessoas)

        public virtual IEnumerable<Editora> Editoras { get; internal set; } //relação um para muitos (um endereço - muitas editoras)

        public Endereco()
        {

        }

        public Endereco(int enderecoId, string cep, string logradouro, string bairro, int municipioId)
        {
            EnderecoId = enderecoId;
            CEP = cep;
            Logradouro = logradouro;
            Bairro = bairro;
            MunicipioId = municipioId;
        }

    }
}
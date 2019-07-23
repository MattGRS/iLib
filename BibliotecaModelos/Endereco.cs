using System.Collections.Generic;

namespace BibliotecaModelos
{
    public class Endereco
    {
        public int EnderecoId { get; set; }
        public string CEP { get; internal set; } //Ver como fazer a verificação pelos correios;
        public string Logradouro { get; internal set; }
        public string Bairro { get; internal set; }
        public int NumeroResidencial { get; internal set; }
        public string Complemento { get; internal set; }
        public Municipio Municipio { get; private set; } //FK de Municipio
        public IList<Pessoa> Pessoas { get; internal set; } //relação um para muitos (um endereço - muitas pessoas)
        public IList<Editora> Editoras { get; internal set; } //relação um para muitos (um endereço - muitas editoras)

    }
}
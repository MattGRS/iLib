using System.Collections.Generic;

namespace BibliotecaModelos
{
    public class Municipio
    {
        public int MunicipioId { get; set; }
        public string NomeMunicipio { get;  internal set; }
        public Estado Estado { get; internal set; } //FK de Estado
        public IList<Endereco> Enderecos { get; internal set; } //relação um para muitos (um municipio - muitos enderecos)
    }
}
using System.Collections.Generic;


namespace BibliotecaDominio
{
    public class Municipio
    {
        public int MunicipioId { get; set; }
        public string NomeMunicipio { get;  internal set; }
        public Estado Estado { get; internal set; } //FK de Estado
        public IEnumerable<Endereco> Enderecos { get; internal set; } //relação um para muitos (um municipio - muitos enderecos)
    }
}
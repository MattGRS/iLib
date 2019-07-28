using System.Collections.Generic;

namespace BibliotecaDominio
{
    public class Pais
    {
        public int PaisId { get; set; }
        public string NomePais { get; internal set; }
        public IEnumerable<Estado> Estados { get; internal set; } //relação um para muitos (um pais - muitos estados)
    }
}
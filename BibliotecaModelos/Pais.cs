using System.Collections.Generic;

namespace BibliotecaModelos
{
    public class Pais
    {
        public int PaisId { get; set; }
        public string NomePais { get; internal set; }
        public IList<Estado> Estados { get; internal set; } //relação um para muitos (um pais - muitos estados)
    }
}
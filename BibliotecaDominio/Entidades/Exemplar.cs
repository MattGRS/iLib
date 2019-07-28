
namespace BibliotecaDominio
{
    public class Exemplar
    {
        public int ExemplarId { get; set; }
        public string Registro { get; internal set; }
        public int NumeroExemplar { get; internal set; }
        public Livro Livro { get; internal set; } //FK de Livro
    }
}

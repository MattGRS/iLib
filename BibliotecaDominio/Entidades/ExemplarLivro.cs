
namespace BibliotecaDominio.Entidades
{
    public class ExemplarLivro
    {
        public int ExemplarLivroId { get; set; }
        public string Registro { get; internal set; }
        public int NumeroExemplar { get; internal set; }
        public Livro Livro { get; internal set; } //FK de Livro
    }
}

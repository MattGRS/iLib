using BibliotecaDominio.ObjetosValor;
using System.Collections.Generic;

namespace BibliotecaDominio.Entidades
{
    /// <summary>
    /// Define uma 
    /// </summary>
    public class Livro
    {
        public int LivroId { get; set; }
        public string Titulo { get; internal set; }
        public Autor Autor { get; internal set; } //FK de autor
        public Editora Editora { get; internal set; } //FK de Editora
        public Assunto Assunto { get; internal set; } //FK de Assunto
        public Classificacao Classificacao { get; internal set; } //FK de Classificacao
        public Localizacao Localizacao { get; set; } //FK de Localizacao
        public IEnumerable<ExemplarLivro> Exemplares { get; internal set; } //relação um para muitos (um livro - muitos exemplares)
    }
}

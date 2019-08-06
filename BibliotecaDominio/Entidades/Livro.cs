using BibliotecaDominio.ObjetosValor;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BibliotecaDominio.Entidades
{
    /// <summary>
    /// Define uma 
    /// </summary>
    public class Livro
    {
        public int LivroId { get; set; }
        [Required,MaxLength(100) ]
        public string Titulo { get; internal set; }
        [Required]
        public virtual Autor Autor { get; internal set; } //FK de autor
        [Required]
        public virtual Editora Editora { get; internal set; } //FK de Editora
        [Required]
        public virtual Assunto Assunto { get; internal set; } //FK de Assunto
        [Required]
        public virtual Classificacao Classificacao { get; internal set; } //FK de Classificacao
        [Required]
        public virtual Localizacao Localizacao { get; set; } //FK de Localizacao
        public virtual IEnumerable<ExemplarLivro> Exemplares { get; internal set; } //relação um para muitos (um livro - muitos exemplares)
    }
}

using BibliotecaDominio.Entidades;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BibliotecaDominio.ObjetosValor
{
    public class Assunto
    {
        public int AssuntoId { get; set; }
        [Required, MaxLength(50)]
        public string AssuntoObra { get; internal set; }
        public virtual IEnumerable<Livro> Livros { get; internal set; } //Relação um para muitos (um assunto - muitos livros)
    }
}
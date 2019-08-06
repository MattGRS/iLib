using BibliotecaDominio.Entidades;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BibliotecaDominio.ObjetosValor
{
    public class Autor
    {
        public int AutorId { get; set; }
        [Required, MaxLength(50)]
        public string NomeAutor { get; internal set; }
        public virtual IEnumerable<Livro> Livros { get; internal set; } //relação um para muitos (um autos - muitos livros)
    }
}
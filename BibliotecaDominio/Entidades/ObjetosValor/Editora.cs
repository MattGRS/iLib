using BibliotecaDominio.Entidades;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BibliotecaDominio.ObjetosValor
{
    public class Editora
    {
        public int EditoraId { get; set; }
        [Required, MaxLength(50)]
        public string NomeEditora { get; internal set; }
        [Required]
        public virtual Endereco Endereco { get; internal set; } //FK de endereços
        public virtual IEnumerable<Livro> Livros { get; internal set; } //relação um para muitos (uma editora - muitos livros)
    }
}
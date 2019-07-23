using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaModelos
{
    public class Livro
    {
        public int LivroId { get; set; }
        [Required, StringLength(100)]
        public string Titulo { get; internal set; }
        public Autor Autor { get; internal set; } //FK de autor
        public Editora Editora { get; internal set; } //FK de Editora
        public Assunto Assunto { get; internal set; } //FK de Assunto
        public Classificacao Classificacao { get; internal set; } //FK de Classificacao
        public IList<Exemplar> Exemplares { get; internal set; } //relação um para muitos (um livro - muitos exemplares)
    }
}

using BibliotecaDominio.Entidades.ObjetosValor;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BibliotecaDominio.Entidades
{
    public class Livro
    {
        public int LivroId { get; set; }

        [Required,MaxLength(100) ]
        public string Titulo { get; internal set; }

        public int AutorId { get; set; }

        public int EditoraId { get; set; }

        public int AssuntoId { get; set; }

        public int ClassificacaoId { get; set; }

        public int LocalizacaoId { get; set; }

        public virtual Autor Autor { get; internal set; } //FK de autor

        public virtual Editora Editora { get; internal set; } //FK de Editora

        public virtual Assunto Assunto { get; internal set; } //FK de Assunto

        public virtual Classificacao Classificacao { get; internal set; } //FK de Classificacao

        public virtual Localizacao Localizacao { get; set; } //FK de Localizacao

        public virtual IEnumerable<ExemplarLivro> Exemplares { get; internal set; } //relação um para muitos (um livro - muitos exemplares)

    }

}

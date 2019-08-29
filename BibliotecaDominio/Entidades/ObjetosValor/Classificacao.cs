using BibliotecaDominio.Entidades;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BibliotecaDominio.Entidades.ObjetosValor
{
    public class Classificacao
    {
        public int ClassificacaoId { get; set; }

        [Required, MaxLength(100)]
        public string ClassificacaoObra { get; internal set; }

        public virtual IEnumerable<Livro> Livros { get; internal set; } //relação um para muitos (uma classificação - muitos livros)

        public Classificacao(int classificacaoId, string classificacaoObra)
        {
            ClassificacaoId = classificacaoId;
            ClassificacaoObra = classificacaoObra;
        }

    }
}
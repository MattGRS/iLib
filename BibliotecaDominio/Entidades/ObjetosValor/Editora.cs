using BibliotecaDominio.Entidades;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BibliotecaDominio.Entidades.ObjetosValor
{
    public class Editora
    {
        public int EditoraId { get; set; }

        [Required, MaxLength(100)]
        public string NomeEditora { get; internal set; }

        public int EnderecoId { get; set; }

        public virtual Endereco Endereco { get; internal set; } //FK de endereços

        public virtual IEnumerable<Livro> Livros { get; internal set; } //relação um para muitos (uma editora - muitos livros)

        public Editora(int editoraId, string nomeEditora, int enderecoId)
        {
            EditoraId = editoraId;
            NomeEditora = nomeEditora;
            EnderecoId = enderecoId;
        }

    }
}
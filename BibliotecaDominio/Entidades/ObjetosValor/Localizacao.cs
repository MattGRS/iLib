using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BibliotecaDominio.Entidades.ObjetosValor
{
    public class Localizacao
    {
        public int LocalizacaoId { get; set; }

        [Required, MaxLength(100)]
        public string LocalizacaoObra { get; set; }

        public virtual IEnumerable<Livro> Livros { get; set; }

        public Localizacao(int localizacaoId, string localizacaoObra)
        {
            LocalizacaoId = localizacaoId;
            LocalizacaoObra = localizacaoObra;
        }
    }
}
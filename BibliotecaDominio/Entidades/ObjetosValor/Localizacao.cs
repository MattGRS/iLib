using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BibliotecaDominio.Entidades.ObjetosValor
{
    public class Localizacao
    {
        public int LocalizacaoId { get; set; }
        [Required, MaxLength(20)]
        public string LocalizacaoObra { get; set; }
        public virtual IEnumerable<Livro> Livros { get; set; }
    }
}
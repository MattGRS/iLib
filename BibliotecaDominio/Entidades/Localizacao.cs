using System.Collections.Generic;

namespace BibliotecaDominio.Entidades
{
    public class Localizacao
    {
        public int LocalizacaoId { get; set; }
        public string LocalizacaoObra { get; set; }
        public IEnumerable<Livro> Livros { get; set; }
    }
}
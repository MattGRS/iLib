using System.Collections.Generic;

namespace BibliotecaDominio
{
    public class Classificacao
    {
        public int ClassificacaoId { get; set; }
        public string ClassificacaoObra { get; internal set; }
        public IEnumerable<Livro> Livros { get; internal set; } //relação um para muitos (uma classificação - muitos livros)
    }
}
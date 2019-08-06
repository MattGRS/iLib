using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BibliotecaDominio.ObjetosValor
{
    public class DadosLogin
    {
        [Key, ForeignKey("Pessoa")]
        public int PessoaId { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
    }
}
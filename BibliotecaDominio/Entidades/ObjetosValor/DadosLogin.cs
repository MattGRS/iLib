using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BibliotecaDominio.Entidades.ObjetosValor
{
    public class DadosLogin
    {
        [Key, ForeignKey("Pessoa")]
        public int PessoaId { get; set; }
        [Required]
        public string Login { get; internal set; }
        [Required]
        public string Senha { get; internal set; }
    }
}
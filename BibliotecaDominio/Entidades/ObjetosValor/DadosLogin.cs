using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BibliotecaDominio.Entidades.ObjetosValor
{
    public class DadosLogin
    {
        public int DadosLoginId { get; set; }

        [Required, MaxLength(100)]
        public string Login { get; internal set; }

        [Required, MaxLength(100)]
        public string Senha { get; internal set; }

        public DadosLogin(int dadosLoginId, string login, string senha)
        {
            DadosLoginId = dadosLoginId;
            Login = login;
            Senha = senha;
        }
    }
}
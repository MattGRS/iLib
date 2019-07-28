
namespace BibliotecaDominio
{
    public class Usuario
    {
        //Pessoa recebe Usuário ou o inverso?
        //Fazer uma classe validação de Login e Senha (Credenciais de Acesso)
        public int UsuarioId { get; set; }
        public string Login { get; internal set; }
        public string Senha { get; internal set; }
        public Pessoa Pessoa { get; set; }
    }
}

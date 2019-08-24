using BibliotecaDominio.Entidades.ObjetosValor;
using BibliotecaDominio.Interfaces.Repositorio;
using System.Linq;

namespace BibliotecaDados.Repositorios
{
    public class DadosLoginRepositorio : BibliotecaRepositorioBase<DadosLogin>, IDadosLoginRepositorio
    {
        public DadosLogin SearchUser(string login, string senha)
        {
            var usuario = Db.Set<DadosLogin>().ToList();
            var usuarioEncontrado = usuario.First(p => p.Login == login && p.Senha == senha);
            return (usuarioEncontrado);
        }
        public new bool Remover(DadosLogin dadosLogin)
        {
            if (Db.Pessoas.ToList().Exists(p => p.DadosLoginId == dadosLogin.DadosLoginId))
            {
                return false;
            }

            Db.DadosLogin.Remove(dadosLogin);
            Db.SaveChanges();
            return true;
        }
    }
}

using BibliotecaDominio.Entidades.ObjetosValor;
using BibliotecaDominio.Interfaces.Repositorio;
using System.Linq;

namespace BibliotecaDados.Repositorios
{
    public class LocalizacaoRepositorio : BibliotecaRepositorioBase<Localizacao>, ILocalizacaoRepositorio
    {
        public new bool Remover(Localizacao localizacao)
        {
            if (Db.Livros.ToList().Exists(l => l.LocalizacaoId == localizacao.LocalizacaoId))
            {
                return false;
            }
            Db.Localizacoes.Remove(localizacao);
            Db.SaveChanges();
            return true;
        }
    }
}

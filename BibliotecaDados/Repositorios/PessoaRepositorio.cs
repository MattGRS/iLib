using BibliotecaDominio.Entidades;
using BibliotecaDominio.Interfaces.Repositorio;
using System.Linq;

namespace BibliotecaDados.Repositorios
{
    public class PessoaRepositorio : BibliotecaRepositorioBase<Pessoa>, IPessoaRepositorio
    {
        public new bool Remover(Pessoa pessoa)
        {
            if (Db.Emprestimos.ToList().Exists(p => p.PessoaId == pessoa.PessoaId))
            {
                return false;
            }

            Db.Pessoas.Remove(pessoa);
            Db.SaveChanges();
            return true;
        }
    }
}

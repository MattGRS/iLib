using BibliotecaDominio.Entidades;
using BibliotecaDominio.Interfaces.Repositorio;
using System.Linq;

namespace BibliotecaDados.Repositorios
{
    public class EmprestimoRepositorio : BibliotecaRepositorioBase<Emprestimo>, IEmprestimoRepositorio
    {
        public new bool Remover(Emprestimo emprestimo)
        {
            if (Db.Pessoas.ToList().Exists(p => p.PessoaId == emprestimo.PessoaId)
                || 
                Db.Exemplares.ToList().Exists(e => e.ExemplarLivroId == emprestimo.ExemplarLivroId))
            {
                return false;
            }

            Db.Emprestimos.Remove(emprestimo);
            Db.SaveChanges();
            return true;
        }
    }
}

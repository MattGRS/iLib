using BibliotecaDominio.Entidades;
using BibliotecaDominio.Interfaces.Repositorio;
using System;
using System.Linq;

namespace BibliotecaDados.Repositorios
{
    public class EmprestimoRepositorio : BibliotecaRepositorioBase<Emprestimo>, IEmprestimoRepositorio
    {
        public void Devolver(int id)
        {
            var emprestimo = ObterPorId(id);
            emprestimo.Devolver();
            Atualizar(emprestimo);
        }

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

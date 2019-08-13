using BibliotecaDominio.Entidades;
using BibliotecaDominio.Interfaces.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaDados.Repositorios
{
    public class LivroRepositorio : BibliotecaRepositorioBase<Livro>, ILivroRepositorio
    {
        public new bool Remover(Livro livro)
        {
            if (Db.Exemplares.ToList().Exists(e => e.LivroId == livro.LivroId))
            {
                return false;
            }

            Db.Livros.Remove(livro);
            Db.SaveChanges();
            return true;
        }
    }
}

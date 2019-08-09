using BibliotecaDominio.Entidades.ObjetosValor;
using BibliotecaDominio.Interfaces.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaDados.Repositorios
{
    public class AutorRepositorio : BibliotecaRepositorioBase<Autor>, IAutorRepositorio
    {
        public new bool Remover(Autor autor)
        {
            if (Db.Livros.ToList().Exists(l => l.AutorId == autor.AutorId))
            {
                return false;
            }

            Db.Autores.Remove(autor);
            Db.SaveChanges();
            return true;
        }
    }
}

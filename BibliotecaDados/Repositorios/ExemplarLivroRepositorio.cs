using BibliotecaDominio.Entidades;
using BibliotecaDominio.Interfaces.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaDados.Repositorios
{
    public class ExemplarLivroRepositorio : BibliotecaRepositorioBase<ExemplarLivro>, IExemplarLivroRepositorio
    {
        public new bool Remover(ExemplarLivro exemplarLivro)
        {
            Db.Exemplares.Remove(exemplarLivro);
            Db.SaveChanges();
            return true;
            
        }
    }
}

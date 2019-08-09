using BibliotecaDados.Contexto;
using BibliotecaDominio.Interfaces.Repositorio;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaDados.Repositorios
{
    public class BibliotecaRepositorioBase<TEntidade> : IDisposable, IBibliotecaRepositorioBase<TEntidade> where TEntidade : class
    {
        protected BibliotecaContext Db = new BibliotecaContext();
        public void Adicionar(TEntidade entidade)
        {
            Db.Set<TEntidade>().Add(entidade);
            Db.SaveChanges();
        }

        public void Atualizar(TEntidade entidade)
        {
            Db.Entry(entidade).State = EntityState.Modified;
            Db.SaveChanges();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public TEntidade ObterPorId(int id)
        {
            return Db.Set<TEntidade>().Find(id);
        }

        public IEnumerable<TEntidade> ObterTodos()
        {
            return Db.Set<TEntidade>().ToList();
        }

        public void Remover(TEntidade entidade)
        {
            Db.Set<TEntidade>().Remove(entidade);
            Db.SaveChanges();
        }
    }
}

using BibliotecaDominio.Interfaces.Repositorio;
using BibliotecaDominio.Interfaces.Servicos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaDominio.Servicos
{
    public class BibliotecaServicoBase<TEntidade> : IDisposable, IBibliotecaServicoBase<TEntidade> where TEntidade : class
    {
        private readonly IBibliotecaRepositorioBase<TEntidade> _bibliotecaRepositorio;

        public BibliotecaServicoBase(IBibliotecaRepositorioBase<TEntidade> repositorio)
        {
            _bibliotecaRepositorio = repositorio;
        }
        public void Adicionar(TEntidade entidade)
        {
            _bibliotecaRepositorio.Adicionar(entidade);
        }

        public void Atualizar(TEntidade entidade)
        {
            _bibliotecaRepositorio.Atualizar(entidade);
        }

        public void Dispose()
        {
            _bibliotecaRepositorio.Dispose();
        }

        public TEntidade ObterPorId(int id)
        {
            return _bibliotecaRepositorio.ObterPorId(id);
        }

        public IEnumerable<TEntidade> ObterTodos()
        {
            return _bibliotecaRepositorio.ObterTodos();
        }

        public void Remover(TEntidade entidade)
        {
            _bibliotecaRepositorio.Remover(entidade);
        }
    }
}

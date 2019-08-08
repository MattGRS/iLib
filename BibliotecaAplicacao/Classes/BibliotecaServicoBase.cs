using BibliotecaAplicacao.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaAplicacao.Classes
{
    class BibliotecaServicoBase<TEntidade> : IDisposable, IBibliotecaServicoBase<TEntidade> where TEntidade : class
    {
        private readonly IBibliotecaServicoBase<TEntidade> _servicoBase;

        public BibliotecaServicoBase(IBibliotecaServicoBase<TEntidade> servicoBase)
        {
            _servicoBase = servicoBase;
        }

        public void Adicionar(TEntidade entidade)
        {
            _servicoBase.Adicionar(entidade);
        }

        public void Atualizar(TEntidade entidade)
        {
            _servicoBase.Atualizar(entidade);
        }

        public void Dispose()
        {
            _servicoBase.Dispose();
        }

        public TEntidade ObterPorId(int id)
        {
            return _servicoBase.ObterPorId(id);
        }

        public IEnumerable<TEntidade> ObterTodos()
        {
            return _servicoBase.ObterTodos();
        }

        public void Remover(TEntidade entidade)
        {
            _servicoBase.Remover(entidade);
        }
    }
}

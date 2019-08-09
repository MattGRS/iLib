using BibliotecaAplicacao.Interfaces;
using BibliotecaDominio.Interfaces.Servicos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaAplicacao.Classes
{
    public class BibliotecaAppServico<TEntidade> : IDisposable, IBibliotecaAppServicoBase<TEntidade> where TEntidade : class
    {
        private readonly IBibliotecaServicoBase<TEntidade> _bibliotecaServicoBase;

        public BibliotecaAppServico(IBibliotecaServicoBase<TEntidade> bibliotecaServicoBase)
        {
            _bibliotecaServicoBase = bibliotecaServicoBase;
        }
        public void Adicionar(TEntidade entidade)
        {
            _bibliotecaServicoBase.Adicionar(entidade);
        }

        public void Atualizar(TEntidade entidade)
        {
            _bibliotecaServicoBase.Atualizar(entidade);
        }

        public void Dispose()
        {
            _bibliotecaServicoBase.Dispose();
        }

        public TEntidade ObterPorId(int id)
        {
           return _bibliotecaServicoBase.ObterPorId(id);
        }

        public IEnumerable<TEntidade> ObterTodos()
        {
            return _bibliotecaServicoBase.ObterTodos();
        }

        public void Remover(TEntidade entidade)
        {
            _bibliotecaServicoBase.Remover(entidade);
        }
    }
}

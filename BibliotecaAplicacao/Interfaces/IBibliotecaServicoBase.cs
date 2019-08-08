using System.Collections.Generic;

namespace BibliotecaAplicacao.Interfaces
{
    public interface IBibliotecaServicoBase<TEntidade> where TEntidade : class
    {
        void Adicionar(TEntidade entidade);

        void Atualizar(TEntidade entidade);

        void Remover(TEntidade entidade);

        void Dispose();

        TEntidade ObterPorId(int id);

        IEnumerable<TEntidade> ObterTodos();
    }
}

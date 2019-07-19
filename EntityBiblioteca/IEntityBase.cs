using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityBiblioteca
{
    interface IEntityBase<T> where T : class
    {
        void Adicionar(T entidade);
        void Atualizar(T entidade);
        void Remover(T entidade);
        //IList<T> Lista();
    }
}

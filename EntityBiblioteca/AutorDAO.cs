using BibliotecaModelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityBiblioteca
{
    public class AutorDAO : IEntityBase<Autor>
    {
        public void Adicionar(Autor entidade)
        {
            using (var contexto = new BibliotecaContext())
            {
                contexto.Autores.Add(entidade);
                contexto.SaveChanges();
            }
        }

        public void Atualizar(Autor entidade)
        {
            throw new NotImplementedException();
        }

        public void Remover(Autor entidade)
        {
            throw new NotImplementedException();
        }
    }
}

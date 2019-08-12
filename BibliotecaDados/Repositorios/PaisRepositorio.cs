using BibliotecaDominio.Entidades.ObjetosValor;
using BibliotecaDominio.Interfaces.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaDados.Repositorios
{
    public class PaisRepositorio : BibliotecaRepositorioBase<Pais>, IPaisRepositorio
    {
        public new bool Remover(Pais pais)
        {
            if (Db.Estados.ToList().Exists(e => e.PaisId == pais.PaisId))
            {
                return false;
            }

            Db.Paises.Remove(pais);
            Db.SaveChanges();
            return true;
        }
    }
}

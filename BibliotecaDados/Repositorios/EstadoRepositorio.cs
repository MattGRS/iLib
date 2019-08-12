using BibliotecaDominio.Entidades.ObjetosValor;
using BibliotecaDominio.Interfaces.Repositorio;
using System.Linq;

namespace BibliotecaDados.Repositorios
{
    public class EstadoRepositorio : BibliotecaRepositorioBase<Estado>, IEstadoRepositorio
    {
        public new bool Remover(Estado estado)
        {
            if (Db.Municipios.ToList().Exists(m => m.EstadoId == estado.EstadoId))
            {
                return false;
            }

            Db.Estados.Remove(estado);
            Db.SaveChanges();
            return true;
        }
    }
}

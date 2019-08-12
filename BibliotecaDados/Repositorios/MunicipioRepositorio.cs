using BibliotecaDominio.Entidades.ObjetosValor;
using BibliotecaDominio.Interfaces.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaDados.Repositorios
{
    public class MunicipioRepositorio : BibliotecaRepositorioBase<Municipio>, IMunicipioRepositorio
    {
        public new bool Remover(Municipio municipio)
        {
            if (Db.Enderecos.ToList().Exists(e => e.MunicipioId == municipio.MunicipioId))
            {
                return false;
            }

            Db.Municipios.Remove(municipio);
            Db.SaveChanges();
            return true;
        }
    }
}

using BibliotecaDominio.Entidades.ObjetosValor;
using BibliotecaDominio.Interfaces.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaDados.Repositorios
{
    public class AssuntoRepositorio : BibliotecaRepositorioBase<Assunto>, IAssuntoRepositorio
    {
        public new bool Remover(Assunto assunto)
        {
            if (Db.Livros.ToList().Exists(l => l.AssuntoId == assunto.AssuntoId))
            {
                return false;
            }

            Db.Assuntos.Remove(assunto);
            Db.SaveChanges();
            return true;
        }
    }
}

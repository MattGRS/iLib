using BibliotecaDominio.Entidades.ObjetosValor;
using BibliotecaDominio.Interfaces.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaDados.Repositorios
{
    public class EditoraRepositorio : BibliotecaRepositorioBase<Editora>, IEditoraRepositorio
    {
        public new bool Remover(Editora editora)
        {
            if (Db.Livros.ToList().Exists(l => l.EditoraId == editora.EditoraId))
            {
                return false;
            }

            Db.Editoras.Remove(editora);
            Db.SaveChanges();
            return true;
        }
    }
}

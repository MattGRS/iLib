using BibliotecaDominio.Entidades.ObjetosValor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaDominio.Interfaces.Repositorio
{
    public interface IAutorRepositorio : IBibliotecaRepositorioBase<Autor>
    {
        new bool Remover(Autor autor);
    }
}

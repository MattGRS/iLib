using BibliotecaDominio.Entidades.ObjetosValor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaDominio.Interfaces.Repositorio
{
    public interface IAssuntoRepositorio : IBibliotecaRepositorioBase<Assunto>
    {
        new bool Remover(Assunto assunto);
    }
}

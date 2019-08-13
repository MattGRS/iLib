using BibliotecaDominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaDominio.Interfaces.Repositorio
{
    public interface IExemplarLivroRepositorio : IBibliotecaRepositorioBase<ExemplarLivro>
    {
        new bool Remover(ExemplarLivro exemplarLivro);
    }
}

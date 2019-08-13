using BibliotecaDominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaDominio.Interfaces.Servicos
{
    public interface ILivroServico : IBibliotecaServicoBase<Livro>
    {
        new bool Remover(Livro livro);
    }
}

using BibliotecaDominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaAplicacao.Interfaces
{
    public interface ILivroAppServico : IBibliotecaAppServicoBase<Livro>
    {
        new bool Remover(Livro livro);
    }
}

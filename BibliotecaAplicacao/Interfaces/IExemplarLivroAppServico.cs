using BibliotecaDominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaAplicacao.Interfaces
{
    public interface IExemplarLivroAppServico : IBibliotecaAppServicoBase<ExemplarLivro>
    {
        new bool Remover(ExemplarLivro exemplarLivro);
    }
}

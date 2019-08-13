using BibliotecaDominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaAplicacao.Interfaces
{
    public interface IEmprestimoAppServico : IBibliotecaAppServicoBase<Emprestimo>
    {
        new bool Remover(Emprestimo emprestimo);
    }
}

using BibliotecaDominio.Entidades.ObjetosValor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaAplicacao.Interfaces
{
    public interface IAssuntoServico : IBibliotecaServicoBase<Assunto>
    {
        new bool Remover(Assunto assunto);
    }
}

using BibliotecaDominio.Entidades.ObjetosValor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaDominio.Interfaces.Servicos
{
    public interface IAutorServico : IBibliotecaServicoBase<Autor>
    {
        new bool Remover(Autor autor);
    }
}

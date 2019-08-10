using BibliotecaDominio.Entidades.ObjetosValor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaDominio.Interfaces.Servicos
{
    public interface IDadosLoginServico : IBibliotecaServicoBase<DadosLogin>
    {
        new bool Remover(DadosLogin dadosLogin);
    }
}

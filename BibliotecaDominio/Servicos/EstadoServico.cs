using BibliotecaDominio.Entidades.ObjetosValor;
using BibliotecaDominio.Interfaces.Repositorio;
using BibliotecaDominio.Interfaces.Servicos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaDominio.Servicos
{
    public class EstadoServico : BibliotecaServicoBase<Estado>, IEstadoServico
    {
        private readonly IEstadoRepositorio _estadoRespositorio;

        public EstadoServico(IEstadoRepositorio estadoRepositorio) : base(estadoRepositorio)
        {
            _estadoRespositorio = estadoRepositorio;
        }

        public new bool Remover(Estado estado)
        {
            return _estadoRespositorio.Remover(estado);
        }
    }
}

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
    public class PaisServico : BibliotecaServicoBase<Pais>, IPaisServico
    {
        private readonly IPaisRepositorio _paisRepositorio;

        public PaisServico(IPaisRepositorio paisRepositorio) : base(paisRepositorio)
        {
            _paisRepositorio = paisRepositorio;
        }

        public new bool Remover(Pais pais)
        {
            return _paisRepositorio.Remover(pais);
        }
    }
}

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
    public class AssuntoServico : BibliotecaServicoBase<Assunto>, IAssuntoServico
    {
        private readonly IAssuntoRepositorio _assuntoRepositorio;
        public AssuntoServico(IAssuntoRepositorio assuntoRepositorio) : base(assuntoRepositorio)
        {
            _assuntoRepositorio = assuntoRepositorio;
        }

        public new bool Remover(Assunto assunto)
        {
            return _assuntoRepositorio.Remover(assunto);
        }
    }
}

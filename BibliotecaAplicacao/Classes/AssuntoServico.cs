using BibliotecaAplicacao.Interfaces;
using BibliotecaDominio.Entidades.ObjetosValor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaAplicacao.Classes
{
    class AssuntoServico : BibliotecaServicoBase<Assunto>, IAssuntoServico
    {
        private readonly IAssuntoServico _assuntoServico;
        public AssuntoServico(IAssuntoServico servicoBase) : base(servicoBase)
        {
            _assuntoServico = servicoBase;
        }

        bool IAssuntoServico.Remover(Assunto assunto)
        {
            return _assuntoServico.Remover(assunto);
        }
    }
}

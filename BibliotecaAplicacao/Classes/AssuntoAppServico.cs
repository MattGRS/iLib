using BibliotecaAplicacao.Interfaces;
using BibliotecaDominio.Entidades.ObjetosValor;
using BibliotecaDominio.Interfaces.Servicos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaAplicacao.Classes
{
    class AssuntoAppServico : BibliotecaAppServico<Assunto>, IAssuntoAppServico
    {
        private readonly IAssuntoServico _assuntoServico;

        public AssuntoAppServico(IAssuntoServico assuntoServico) : base(assuntoServico)
        {
            _assuntoServico = assuntoServico;
        }
        public new bool Remover(Assunto assunto)
        {
            return _assuntoServico.Remover(assunto);
        }
    }
}

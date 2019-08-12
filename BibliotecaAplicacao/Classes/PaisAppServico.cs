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
    public class PaisAppServico : BibliotecaAppServico<Pais>, IPaisAppServico
    {
        private readonly IPaisServico _paisServico;

        public PaisAppServico(IPaisServico paisServico) : base(paisServico)
        {
            _paisServico = paisServico;
        }

        public new bool Remover(Pais pais)
        {
            return _paisServico.Remover(pais);
        }
    }
}

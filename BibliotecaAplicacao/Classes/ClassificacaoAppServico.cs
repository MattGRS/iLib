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
    public class ClassificacaoAppServico : BibliotecaAppServico<Classificacao>, IClassificacaoAppServico
    {
        private readonly IClassificacaoServico _classificacaoServico;

        public ClassificacaoAppServico(IClassificacaoServico classificacaoServico) : base(classificacaoServico)
        {
            _classificacaoServico = classificacaoServico;
        }

        public new bool Remover(Classificacao classificacao)
        {
            return _classificacaoServico.Remover(classificacao);
        }
    }
}

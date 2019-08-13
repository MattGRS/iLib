using BibliotecaAplicacao.Interfaces;
using BibliotecaDominio.Entidades;
using BibliotecaDominio.Interfaces.Servicos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaAplicacao.Classes
{
    public class ExemplarLivroAppServico : BibliotecaAppServico<ExemplarLivro>, IExemplarLivroAppServico
    {
        private readonly IExemplarLivroServico _exemplarLivroServico;

        public ExemplarLivroAppServico(IExemplarLivroServico exemplarLivroServico) : base(exemplarLivroServico)
        {
            _exemplarLivroServico = exemplarLivroServico;
        }

        public new bool Remover(ExemplarLivro exemplarLivro)
        {
            return _exemplarLivroServico.Remover(exemplarLivro);
        }
    }
}

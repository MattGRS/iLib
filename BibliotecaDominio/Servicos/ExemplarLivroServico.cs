using BibliotecaDominio.Entidades;
using BibliotecaDominio.Interfaces.Repositorio;
using BibliotecaDominio.Interfaces.Servicos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaDominio.Servicos
{
    public class ExemplarLivroServico : BibliotecaServicoBase<ExemplarLivro>, IExemplarLivroServico
    {
        private readonly IExemplarLivroRepositorio _exemplarLivroRepositorio;

        public ExemplarLivroServico(IExemplarLivroRepositorio exemplarLivroRepositorio) : base(exemplarLivroRepositorio)
        {
            _exemplarLivroRepositorio = exemplarLivroRepositorio;
        }

        public new bool Remover(ExemplarLivro exemplarLivro)
        {
            return _exemplarLivroRepositorio.Remover(exemplarLivro);
        }
    }
}

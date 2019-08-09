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
    public class ClassificacaoServico : BibliotecaServicoBase<Classificacao>, IClassificacaoServico
    {
        private readonly IClassificacaoRepositorio _classificacaoRepositorio;

        public ClassificacaoServico(IClassificacaoRepositorio classificacaoRepositorio) : base(classificacaoRepositorio)
        {
            _classificacaoRepositorio = classificacaoRepositorio;
        }

        public new bool Remover(Classificacao classificacao)
        {
            return _classificacaoRepositorio.Remover(classificacao);
        }
    }
}

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
    public class LivroAppServico : BibliotecaAppServico<Livro>, ILivroAppServico
    {
        private readonly ILivroServico _livroServico;

        public LivroAppServico(ILivroServico livroServico) : base(livroServico)
        {
            _livroServico = livroServico;
        }

        public new bool Remover(Livro livro)
        {
            return _livroServico.Remover(livro);
        }
    }
}

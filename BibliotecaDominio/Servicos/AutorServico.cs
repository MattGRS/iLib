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
    public class AutorServico : BibliotecaServicoBase<Autor>, IAutorServico
    {
        private readonly IAutorRepositorio _autorRepositorio;

        public AutorServico(IAutorRepositorio autorRepositorio) : base(autorRepositorio)
        {
            _autorRepositorio = autorRepositorio;
        }

        public new bool Remover(Autor autor)
        {
            return _autorRepositorio.Remover(autor);
        }
    }
}

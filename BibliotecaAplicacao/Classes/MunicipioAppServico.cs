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
    public class MunicipioAppServico : BibliotecaAppServico<Municipio>, IMunicipioAppServico
    {
        private readonly IMunicipioServico _municipioServico;

        public MunicipioAppServico(IMunicipioServico municipioServico) : base(municipioServico)
        {
            _municipioServico = municipioServico;
        }

        public new bool Remover(Municipio municipio)
        {
            return _municipioServico.Remover(municipio);
        }
    }
}

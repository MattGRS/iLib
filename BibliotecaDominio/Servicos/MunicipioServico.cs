using BibliotecaDominio.Entidades.ObjetosValor;
using BibliotecaDominio.Interfaces.Repositorio;
using BibliotecaDominio.Interfaces.Servicos;

namespace BibliotecaDominio.Servicos
{
    public class MunicipioServico : BibliotecaServicoBase<Municipio>, IMunicipioServico
    {
        private readonly IMunicipioRepositorio _municipioRepositorio;

        public MunicipioServico(IMunicipioRepositorio municipioRepositorio) : base(municipioRepositorio)
        {
            _municipioRepositorio = municipioRepositorio;
        }

        public new bool Remover(Municipio municipio)
        {
            return _municipioRepositorio.Remover(municipio);
        }
    }
}

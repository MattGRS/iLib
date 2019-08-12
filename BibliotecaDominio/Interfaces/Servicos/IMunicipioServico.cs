using BibliotecaDominio.Entidades.ObjetosValor;

namespace BibliotecaDominio.Interfaces.Servicos
{
    public interface IMunicipioServico : IBibliotecaServicoBase<Municipio>
    {
        new bool Remover(Municipio municipio);
    }
}

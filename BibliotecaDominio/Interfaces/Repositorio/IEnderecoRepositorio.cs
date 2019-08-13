using BibliotecaDominio.Entidades;

namespace BibliotecaDominio.Interfaces.Repositorio
{
    public interface IEnderecoRepositorio : IBibliotecaRepositorioBase<Endereco>
    {
        new bool Remover(Endereco endereco);
    }
}

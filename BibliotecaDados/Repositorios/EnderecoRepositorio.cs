using BibliotecaDominio.Entidades;
using BibliotecaDominio.Interfaces.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaDados.Repositorios
{
    public class EnderecoRepositorio : BibliotecaRepositorioBase<Endereco>, IEnderecoRepositorio
    {
        public new bool Remover(Endereco endereco)
        {
            if (Db.Editoras.ToList().Exists(e => e.EnderecoId == endereco.EnderecoId)
                || 
                Db.Pessoas.ToList().Exists(p => p.EnderecoId == endereco.EnderecoId))
            {
                return false;
            }

            Db.Enderecos.Remove(endereco);
            Db.SaveChanges();
            return true;
        }
    }
}

using BibliotecaDominio.Entidades.ObjetosValor;
using BibliotecaDominio.Interfaces.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaDados.Repositorios
{
    public class ClassificacaoRepositorio : BibliotecaRepositorioBase<Classificacao>, IClassificacaoRepositorio
    {
        public new bool Remover(Classificacao classificacao)
        {
            if (Db.Livros.ToList().Exists(l => l.ClassificacaoId == classificacao.ClassificacaoId))
            {
                return false;
            }

            Db.Classificacoes.Remove(classificacao);
            Db.SaveChanges();
            return true;
        }
    }
}

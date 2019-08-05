using BibliotecaDominio.ObjetosValor;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaDados.EntidadesConfig
{
    class ClassificacaoConfig : IEntityTypeConfiguration<Classificacao>
    {
        public void Configure(EntityTypeBuilder<Classificacao> builder)
        {
            builder
                .Property(c => c.ClassificacaoObra)
                .IsRequired();
        }
    }
}

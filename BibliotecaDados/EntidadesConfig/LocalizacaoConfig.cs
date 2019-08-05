using BibliotecaDominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaDados.EntidadesConfig
{
    class LocalizacaoConfig : IEntityTypeConfiguration<Localizacao>
    {
        public void Configure(EntityTypeBuilder<Localizacao> builder)
        {
            builder
                .Property(l => l.LocalizacaoObra)
                .IsRequired()
                .HasMaxLength(20);
        }
    }
}

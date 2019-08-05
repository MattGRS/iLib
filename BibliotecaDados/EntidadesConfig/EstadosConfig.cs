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
    class EstadosConfig : IEntityTypeConfiguration<Estado>
    {
        public void Configure(EntityTypeBuilder<Estado> builder)
        {
            builder
                .Property(e => e.NomeEstado)
                .IsRequired()
                .HasMaxLength(50);
        }
    }
}

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
    class PaisConfig : IEntityTypeConfiguration<Pais>
    {
        public void Configure(EntityTypeBuilder<Pais> builder)
        {
            builder
                .Property(p => p.NomePais)
                .IsRequired()
                .HasMaxLength(50);
        }
    }
}

using BibliotecaDominio;
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
    public class AssuntoConfig : IEntityTypeConfiguration<Assunto>
    {
        //Como impedir registros iguais??
        public void Configure(EntityTypeBuilder<Assunto> builder)
        {
            builder
                .Property(a => a.AssuntoObra)
                .IsRequired();
            builder
                .Property(a => a.AssuntoObra)
                .HasMaxLength(50);
        }
    }
}

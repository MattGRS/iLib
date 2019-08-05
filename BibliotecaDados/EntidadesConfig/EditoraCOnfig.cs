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
    class EditoraConfig : IEntityTypeConfiguration<Editora>
    {
        public void Configure(EntityTypeBuilder<Editora> builder)
        {
            builder
                .Property(e => e.NomeEditora)
                .IsRequired()
                .HasMaxLength(50);
            builder
                .Property(e => e.Endereco)
                .IsRequired();
        }
    }
}

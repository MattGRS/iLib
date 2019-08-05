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
    class EnderecoConfig : IEntityTypeConfiguration<Endereco>
    {
        public void Configure(EntityTypeBuilder<Endereco> builder)
        {
            builder
                .Property(e => e.CEP)
                .IsRequired()
                .HasMaxLength(10);
            builder
                .Property(e => e.Logradouro)
                .IsRequired()
                .HasMaxLength(70);
            builder
                .Property(e => e.Bairro)
                .IsRequired()
                .HasMaxLength(50);
            builder
                .Property(e => e.Municipio)
                .IsRequired();
        }
    }
}

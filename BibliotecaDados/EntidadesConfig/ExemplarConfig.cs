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
    class ExemplarConfig : IEntityTypeConfiguration<ExemplarLivro>
    {
        public void Configure(EntityTypeBuilder<ExemplarLivro> builder)
        {
            builder
                .Property(e => e.Registro)
                .IsRequired();
            builder
                .Property(e => e.Livro)
                .IsRequired();
        }
    }
}

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
    class ExemplarLivroConfig : IEntityTypeConfiguration<ExemplarLivro>
    {
        public void Configure(EntityTypeBuilder<ExemplarLivro> builder)
        {
            builder
                .HasMany(e => e.Emprestimo)
                .WithOne(e => e.ExemplarLivro)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}

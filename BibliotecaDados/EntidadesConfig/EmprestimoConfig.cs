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
    class EmprestimoConfig : IEntityTypeConfiguration<Emprestimo>
    {
        public void Configure(EntityTypeBuilder<Emprestimo> builder)
        {
            builder
                .HasOne(e => e.ExemplarLivro)
                .WithMany(e => e.Emprestimo)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(e => e.Pessoa)
                .WithMany(p => p.Emprestimo)
                .OnDelete(DeleteBehavior.Restrict);

        }
    }
}

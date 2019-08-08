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
    class PessoaConfig : IEntityTypeConfiguration<Pessoa>
    {
        public void Configure(EntityTypeBuilder<Pessoa> builder)
        {
            builder
                .HasMany(e => e.Emprestimo)
                .WithOne(e => e.Pessoa)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}

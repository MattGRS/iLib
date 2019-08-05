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
    class LivroConfig : IEntityTypeConfiguration<Livro>
    {
        public void Configure(EntityTypeBuilder<Livro> builder)
        {
            builder
                .Property(l => l.Titulo)
                .IsRequired()
                .HasMaxLength(100);
            builder
                .Property(l => l.Autor)
                .IsRequired();
            builder
                .Property(l => l.Editora)
                .IsRequired();
            builder
                .Property(l => l.Assunto)
                .IsRequired();
            builder
                .Property(l => l.Classificacao)
                .IsRequired();
            builder
                .Property(l => l.Localizacao)
                .IsRequired();
        }
    }
}

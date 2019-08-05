using BibliotecaDominio;
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
                .Property(p => p.Nome)
                .IsRequired().HasMaxLength(50);
            builder
                .Property(p => p.CPF)
                .IsRequired();
            builder
                .Property(p => p.RG)
                .IsRequired();
            builder
                .Property(p => p.Endereco)
                .IsRequired();
            builder
                .Property(p => p.Email)
                .IsRequired();
            builder
                .Property(p => p.Login)
                .IsRequired();
        }
    }
}

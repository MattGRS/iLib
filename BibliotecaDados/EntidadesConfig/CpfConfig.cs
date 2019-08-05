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
    class CpfConfig : IEntityTypeConfiguration<CPF>
    {
        public void Configure(EntityTypeBuilder<CPF> builder)
        {
            builder.HasKey("Cpf");
        }
    }
}

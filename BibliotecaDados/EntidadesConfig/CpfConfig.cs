using BibliotecaDominio.Entidades.ObjetosValor;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

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

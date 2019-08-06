using BibliotecaDominio.Entidades.ObjetosValor;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BibliotecaDados.EntidadesConfig
{
    class EstadosConfig : IEntityTypeConfiguration<Estado>
    {
        public void Configure(EntityTypeBuilder<Estado> builder)
        {
            builder
                .Property(e => e.NomeEstado)
                .IsRequired()
                .HasMaxLength(50);
            builder
                .Property(e => e.Pais)
                .IsRequired();
        }
    }
}

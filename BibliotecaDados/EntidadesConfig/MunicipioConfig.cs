using BibliotecaDominio.Entidades.ObjetosValor;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BibliotecaDados.EntidadesConfig
{
    class MunicipioConfig : IEntityTypeConfiguration<Municipio>
    {
        public void Configure(EntityTypeBuilder<Municipio> builder)
        {
            builder
                .Property(m => m.NomeMunicipio)
                .IsRequired()
                .HasMaxLength(50);
            builder
                .Property(m => m.Estado)
                .IsRequired();
        }
    }
}

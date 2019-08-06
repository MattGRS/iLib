using BibliotecaDominio.Entidades.ObjetosValor;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BibliotecaDados.EntidadesConfig
{
    public class AssuntoConfig : IEntityTypeConfiguration<Assunto>
    {
        //Como impedir registros iguais??
        public void Configure(EntityTypeBuilder<Assunto> builder)
        {
            builder
                .Property(a => a.AssuntoObra)
                .IsRequired()
                .HasMaxLength(50);
        }
    }
}

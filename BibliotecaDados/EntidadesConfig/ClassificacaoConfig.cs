using BibliotecaDominio.Entidades.ObjetosValor;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BibliotecaDados.EntidadesConfig
{
    class ClassificacaoConfig : IEntityTypeConfiguration<Classificacao>
    {
        public void Configure(EntityTypeBuilder<Classificacao> builder)
        {
            builder
                .Property(c => c.ClassificacaoObra)
                .IsRequired()
                .HasMaxLength(20);
        }
    }
}

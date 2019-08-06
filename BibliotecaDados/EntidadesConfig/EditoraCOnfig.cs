using BibliotecaDominio.Entidades.ObjetosValor;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BibliotecaDados.EntidadesConfig
{
    class EditoraConfig : IEntityTypeConfiguration<Editora>
    {
        public void Configure(EntityTypeBuilder<Editora> builder)
        {
            builder
                .Property(e => e.NomeEditora)
                .IsRequired()
                .HasMaxLength(50);
            builder
                .Property(e => e.Endereco)
                .IsRequired();
        }
    }
}

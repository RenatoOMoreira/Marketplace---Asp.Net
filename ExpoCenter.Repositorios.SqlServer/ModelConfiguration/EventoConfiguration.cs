using ExpoCenterDominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ExpoCenter.Repositorios.SqlServer.ModelConfiguration
{
    internal class EventoConfiguration : IEntityTypeConfiguration<Evento>
    {
        public void Configure(EntityTypeBuilder<Evento> builder)
        {
            builder.ToTable("Evento");

            builder.HasIndex(e => e.Descricao).IsUnique();

            builder
                .Property(e => e.Descricao)
                .IsRequired()
                .HasMaxLength(50);

            builder
                .Property(e => e.Local)
                .IsRequired()
                .HasMaxLength(50);

            builder
                .Property(e => e.Local)
                .HasPrecision(11, 2);

                
        }
    }
}
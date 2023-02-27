using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Mappings
{
    public class ConatoDocumentoMapping : IEntityTypeConfiguration<ContatoDocumento>
    {
        public void Configure(EntityTypeBuilder<ContatoDocumento> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.numero)
               .IsRequired()
               .HasColumnType("varchar(13)");

             
            builder.HasMany(f => f.EnvioDocumentos)
                .WithOne(p => p.Numero)
                .HasForeignKey(p => p.NumeroId);

            builder.ToTable("tb_contato");
        }
    }
}
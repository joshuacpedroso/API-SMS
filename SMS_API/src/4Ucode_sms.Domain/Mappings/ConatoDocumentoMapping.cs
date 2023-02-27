using Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DevIO.Data.Mappings
{
    public class ConatoDocumentoMapping : IEntityTypeConfiguration<ContatoDocumento>
    {
        public void Configure(EntityTypeBuilder<ContatoDocumento> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.numero)
               .IsRequired()
               .HasColumnType("varchar(11)");

            // 1 : N => Envios : Numeros
            builder.HasMany(f => f.EnvioDocumentos)
                .WithOne(p => p.Numero)
                .HasForeignKey(p => p.NumeroId);

            builder.ToTable("tb_Contatos");
        }
    }
}
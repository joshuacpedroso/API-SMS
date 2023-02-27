using Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DevIO.Data.Mappings
{
    public class EnvioDocumentoMapping : IEntityTypeConfiguration<EnvioDocumento>
    {
        public void Configure(EntityTypeBuilder<EnvioDocumento> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.TextoEnvio)
                .IsRequired()
                .HasColumnType("varchar(260)");


            builder.ToTable("tb_Envio");
        }
    }
}
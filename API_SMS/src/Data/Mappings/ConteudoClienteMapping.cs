using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Mappings
{
    public class ConteudoClienteMapping : IEntityTypeConfiguration<ConteudoCliente>
    {
        public void Configure(EntityTypeBuilder<ConteudoCliente> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Texto)
               .IsRequired()
               .HasColumnType("varchar(450)");

       
            builder.ToTable("tb_conteudo_cliente");
        }
    }
}
using ReciicerAPI.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ReciicerAPI.Data.Configurations
{
    public class EnderecoConfiguration : IEntityTypeConfiguration<Endereco>
    {
        public void Configure(EntityTypeBuilder<Endereco> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Rua).IsRequired().HasMaxLength(200);
            builder.Property(e => e.Numero).IsRequired().HasMaxLength(10);
            builder.Property(e => e.Bairro).IsRequired().HasMaxLength(100);
            builder.Property(e => e.Cidade).IsRequired().HasMaxLength(100);
            builder.Property(e => e.Estado).IsRequired().HasMaxLength(50);
            builder.Property(e => e.Cep).IsRequired().HasMaxLength(9);

            builder.HasIndex(e => new { e.Rua, e.Numero, e.Bairro, e.Cep }).IsUnique();
    
        }

    }

}
using ReciicerAPI.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ReciicerAPI.Data.Configurations
{
    public class ColetaConfiguration : IEntityTypeConfiguration<Coleta>
    {
        public void Configure(EntityTypeBuilder<Coleta> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.DataOperacao).IsRequired();
            builder.Property(c => c.PontuacaoGanha).IsRequired();
            
        }
    }
}
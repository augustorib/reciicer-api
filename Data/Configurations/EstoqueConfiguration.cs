using ReciicerAPI.Models.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace ReciicerAPI.Data.Configurations
{
    public class EstoqueConfiguration : IEntityTypeConfiguration<Estoque>
    {
        public void Configure(EntityTypeBuilder<Estoque> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Capacidade).IsRequired();
            
            builder.ToTable(tb =>
            {
                tb.HasCheckConstraint("CHK_Estoque_Capacidade_NaoNegativa", "Capacidade >= 0");
                tb.HasCheckConstraint("CHK_Estoque_Capacidade", "PesoArmazenado + QuantidadeArmazenada <= Capacidade");
            });
            
        }
    }
}
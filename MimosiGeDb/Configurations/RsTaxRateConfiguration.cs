using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MimosiGeDb.Models;

namespace MimosiGeDb.Configurations;

public sealed class RsTaxRateConfiguration : IEntityTypeConfiguration<RsTaxRate>
{
    public void Configure(EntityTypeBuilder<RsTaxRate> entity)
    {
        entity.HasKey(e => e.Id);

        entity.HasIndex(e => e.Code).IsUnique();

        entity.HasOne(d => d.BenefCategory).WithMany(p => p.RsTaxRates).HasForeignKey(d => d.BenefCategoryId);

        entity.HasOne(d => d.QuoteType).WithMany(p => p.RsTaxRates).HasForeignKey(d => d.QuoteTypeId);
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MimosiGeDb.Models;

namespace MimosiGeDb.Configurations;

public sealed class RsQuoteTypeConfiguration : IEntityTypeConfiguration<RsQuoteType>
{
    public void Configure(EntityTypeBuilder<RsQuoteType> entity)
    {
        entity.HasKey(e => e.QtId);
        entity.HasIndex(e => e.QtName).IsUnique();

        entity.Property(e => e.QtId);
        entity.Property(e => e.QtName).HasMaxLength(255);
    }
}

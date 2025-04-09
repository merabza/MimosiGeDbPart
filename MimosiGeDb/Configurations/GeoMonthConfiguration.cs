using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MimosiGeDb.Models;

namespace MimosiGeDb.Configurations;

public sealed class GeoMonthConfiguration : IEntityTypeConfiguration<GeoMonth>
{
    public void Configure(EntityTypeBuilder<GeoMonth> builder)
    {
        builder.HasKey(e => e.GmnId);

        builder.Property(e => e.GmnDative).HasMaxLength(255);
        builder.Property(e => e.GmnName).HasMaxLength(255);
    }
}
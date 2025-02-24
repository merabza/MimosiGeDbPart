using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MimosiGeDb.Models;

namespace MimosiGeDb.Configurations;

public class GeoMonthConfiguration : IEntityTypeConfiguration<GeoMonth>
{
    public void Configure(EntityTypeBuilder<GeoMonth> builder)
    {
        builder.HasKey(e => e.Id);

        builder.Property(e => e.GmDative).HasMaxLength(255);
        builder.Property(e => e.GmName).HasMaxLength(255);
    }
}

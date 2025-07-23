using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MimosiGeDb.Models;

namespace MimosiGeDb.Configurations;

public sealed class GeoMonthConfiguration : IEntityTypeConfiguration<GeoMonth>
{
    public void Configure(EntityTypeBuilder<GeoMonth> builder)
    {
        builder.HasKey(e => e.GmnId);
        builder.HasIndex(e => e.GmnName).IsUnique();

        builder.Property(e => e.GmnDative).HasMaxLength(255).HasComment("მიცემით ბრუნვაში");
        builder.Property(e => e.GmnName).HasMaxLength(255).HasComment("თვის სახელი");
    }
}
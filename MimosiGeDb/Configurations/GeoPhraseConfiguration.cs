using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MimosiGeDb.Models;

namespace MimosiGeDb.Configurations;

public class GeoPhraseConfiguration : IEntityTypeConfiguration<GeoPhrase>
{
    public void Configure(EntityTypeBuilder<GeoPhrase> builder)
    {
        builder.HasKey(e => e.GpId);

        builder.Property(e => e.GpGeoPhrase).HasMaxLength(1024);
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MimosiGeDbPart.Db.Models;

namespace MimosiGeDbPart.Db.Configurations;

public sealed class RsCountryConfiguration : IEntityTypeConfiguration<RsCountry>
{
    public void Configure(EntityTypeBuilder<RsCountry> builder)
    {
        builder.ToTable("RsCountries", t => t.HasComment("ქვეყნები (შემოსავლების სამსახურის ცნობარი)"));
        builder.HasKey(e => e.Id);
        builder.HasIndex(e => e.Code);

        builder.Property(e => e.Id).HasComment("იდენტიფიკატორი");
        builder.Property(e => e.Code).HasMaxLength(3).HasComment("ქვეყნის კოდი (შემოსავლების სამსახურის)");
        builder.Property(e => e.CountryName).HasMaxLength(255).HasComment("ქვეყნის დასახელება");
    }
}

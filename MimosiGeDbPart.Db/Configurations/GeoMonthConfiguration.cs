using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MimosiGeCore.Domain.Models;

namespace MimosiGeDbPart.Db.Configurations;

public sealed class GeoMonthConfiguration : IEntityTypeConfiguration<GeoMonth>
{
    public void Configure(EntityTypeBuilder<GeoMonth> builder)
    {
        builder.ToTable("GeoMonths", t => t.HasComment("თვეების ქართული სახელები (გადარიცხვის ფაილისთვის)"));
        builder.HasKey(e => e.GmnId);
        builder.HasIndex(e => e.GmnName).IsUnique();

        builder.Property(e => e.GmnId).HasComment("თვის ნომერი (1–12)");
        builder.Property(e => e.GmnDative).HasMaxLength(255).HasComment("მიცემით ბრუნვაში");
        builder.Property(e => e.GmnName).HasMaxLength(255).HasComment("თვის სახელი");
    }
}

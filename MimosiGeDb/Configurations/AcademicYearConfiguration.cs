using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MimosiGeDb.Models;

namespace MimosiGeDb.Configurations;

public sealed class AcademicYearConfiguration : IEntityTypeConfiguration<AcademicYear>
{
    public void Configure(EntityTypeBuilder<AcademicYear> builder)
    {
        builder.HasKey(e => e.AyId);
        builder.HasIndex(e => e.AcademicYearName).IsUnique();

        builder.Property(e => e.AcademicYearName).HasMaxLength(9);
    }
}
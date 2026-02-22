using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MimosiGeDbPart.Db.Models;

namespace MimosiGeDbPart.Db.Configurations;

public sealed class AcademicYearConfiguration : IEntityTypeConfiguration<AcademicYear>
{
    public void Configure(EntityTypeBuilder<AcademicYear> builder)
    {
        builder.HasKey(e => e.AyId);
        builder.HasIndex(e => e.AcademicYearName).IsUnique();

        builder.Property(e => e.AcademicYearName).HasMaxLength(9).HasComment("სასწავლო წლის დასახელება");
        builder.Property(e => e.FinishDate).HasComment("სასწავლო წლის დასასრული");
        builder.Property(e => e.StartDate).HasComment("სასწავლო წლის დასაწყისი");
    }
}

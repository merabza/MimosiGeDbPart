using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MimosiGeDb.Models;

namespace MimosiGeDb.Configurations;

public sealed class LessonMaterialConfiguration : IEntityTypeConfiguration<LessonMaterial>
{
    public void Configure(EntityTypeBuilder<LessonMaterial> builder)
    {
        builder.HasKey(e => e.LmId);

        builder.HasIndex(e => e.LessonId);

        builder.HasIndex(e => e.MaterialId);

        builder.Property(e => e.LmId);
        builder.Property(e => e.MaterialId).HasComment("წიგნი ან მასალა");
        builder.Property(e => e.LessonId).HasComment("გაკვეთილი");

        builder.HasOne(d => d.MaterialNavigation).WithMany(p => p.LessonMaterials).HasForeignKey(d => d.MaterialId)
            .OnDelete(DeleteBehavior.ClientSetNull);

        builder.HasOne(d => d.LessonsNavigation).WithMany(p => p.LessonMaterials).HasForeignKey(d => d.LessonId)
            .OnDelete(DeleteBehavior.ClientSetNull);
    }
}
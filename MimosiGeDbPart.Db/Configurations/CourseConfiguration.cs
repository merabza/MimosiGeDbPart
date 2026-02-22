using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MimosiGeDbPart.Db.Models;

namespace MimosiGeDbPart.Db.Configurations;

public sealed class CourseConfiguration : IEntityTypeConfiguration<Course>
{
    public void Configure(EntityTypeBuilder<Course> builder)
    {
        builder.HasKey(e => e.CrsId);
        builder.HasIndex(e => e.CourseName).IsUnique();

        builder.Property(e => e.CourseName).HasMaxLength(255);
    }
}

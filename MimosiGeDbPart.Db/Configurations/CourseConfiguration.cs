using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MimosiGeCore.Domain.Models;

namespace MimosiGeDbPart.Db.Configurations;

public sealed class CourseConfiguration : IEntityTypeConfiguration<Course>
{
    public void Configure(EntityTypeBuilder<Course> builder)
    {
        builder.ToTable("Courses", t => t.HasComment("საგნები (კურსები)"));
        builder.HasKey(e => e.CrsId);
        builder.HasIndex(e => e.CourseName).IsUnique();

        builder.Property(e => e.CrsId).HasComment("იდენტიფიკატორი");
        builder.Property(e => e.CourseName).HasMaxLength(255).HasComment("საგნის (კურსის) დასახელება");
    }
}

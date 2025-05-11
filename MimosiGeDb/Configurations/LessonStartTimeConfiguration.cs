using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MimosiGeDb.Models;

namespace MimosiGeDb.Configurations;

public sealed class LessonStartTimeConfiguration : IEntityTypeConfiguration<LessonStartTime>
{
    public void Configure(EntityTypeBuilder<LessonStartTime> entity)
    {
        entity.HasKey(e => e.Lstid);

        entity.Property(e => e.Lstid).HasPrecision(0);
    }
}
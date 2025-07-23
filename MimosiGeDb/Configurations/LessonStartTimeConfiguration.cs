using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MimosiGeDb.Models;

namespace MimosiGeDb.Configurations;

public sealed class LessonStartTimeConfiguration : IEntityTypeConfiguration<LessonStartTime>
{
    public void Configure(EntityTypeBuilder<LessonStartTime> entity)
    {
        entity.HasKey(e => e.LstId);

        entity.Property(e => e.LstId);
        entity.Property(e => e.LstTime).HasComment("გაკვეთილის დაწყების დრო");

    }
}
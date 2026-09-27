using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MimosiGeDbPart.Db.Models;

namespace MimosiGeDbPart.Db.Configurations;

public sealed class LessonStartTimeConfiguration : IEntityTypeConfiguration<LessonStartTime>
{
    public void Configure(EntityTypeBuilder<LessonStartTime> entity)
    {
        entity.ToTable("LessonStartTimes", t => t.HasComment("გაკვეთილის დაწყების დროები"));
        entity.HasKey(e => e.LstId);
        entity.HasIndex(e => e.LstTime).IsUnique();

        entity.Property(e => e.LstId).HasComment("იდენტიფიკატორი");
        entity.Property(e => e.LstTime).HasColumnType("time(0)").HasComment("გაკვეთილის დაწყების დრო");
    }
}

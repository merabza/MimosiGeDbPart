using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MimosiGeDbPart.Db.Models;

namespace MimosiGeDbPart.Db.Configurations;

public sealed class LessonStartTimeConfiguration : IEntityTypeConfiguration<LessonStartTime>
{
    public void Configure(EntityTypeBuilder<LessonStartTime> entity)
    {
        entity.HasKey(e => e.LstTime);

        //entity.Property(e => e.LstId);
        entity.Property(e => e.LstTime).HasComment("გაკვეთილის დაწყების დრო");
    }
}

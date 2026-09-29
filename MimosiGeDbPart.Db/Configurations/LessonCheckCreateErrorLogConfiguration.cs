using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MimosiGeCore.Domain.Models;

namespace MimosiGeDbPart.Db.Configurations;

public sealed class LessonCheckCreateErrorLogConfiguration : IEntityTypeConfiguration<LessonCheckCreateErrorLog>
{
    public void Configure(EntityTypeBuilder<LessonCheckCreateErrorLog> builder)
    {
        builder.ToTable("LessonsCheckCreateErrorLogs", t => t.HasComment("გაკვეთილების გენერატორის შეცდომების ლოგი"));
        builder.HasKey(e => e.Id);

        builder.Property(e => e.Id).HasComment("იდენტიფიკატორი");
        builder.Property(e => e.CreatedDate).HasDefaultValueSql("getdate()").HasComment("ლოგის შექმნის თარიღი და დრო");
        builder.Property(e => e.ErrorLogTextId).HasComment("შეცდომის კოდი");
        builder.Property(e => e.GroupId).HasComment("ჯგუფი");
        builder.Property(e => e.LessonDate).HasComment("გაკვეთილის თარიღი");
        builder.Property(e => e.LessonId).HasComment("გაკვეთილი");

        //ლოგი თავის ჯგუფთან, გაკვეთილთან და შეცდომის ტექსტთან ერთად იშლება (Access-შიც Cascade იყო)
        builder.HasOne(d => d.ErrorLogText).WithMany(p => p.LessonsCheckCreateErrorLogs)
            .HasForeignKey(d => d.ErrorLogTextId).OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(d => d.Group).WithMany(p => p.LessonsCheckCreateErrorLogs).HasForeignKey(d => d.GroupId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(d => d.Lesson).WithMany(p => p.LessonsCheckCreateErrorLogs).HasForeignKey(d => d.LessonId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MimosiGeDb.Models;

namespace MimosiGeDb.Configurations;

public sealed class GroupDayTimePlaceConfiguration : IEntityTypeConfiguration<GroupDayTimePlace>
{
    public void Configure(EntityTypeBuilder<GroupDayTimePlace> entity)
    {
        entity.HasKey(e => e.GdtpId);

        entity.HasIndex(e => e.GroupId);

        entity.HasIndex(e => e.RoomId);

        entity.Property(e => e.GdtpId);
        entity.Property(e => e.EndDate).HasComment("გაუქმების თარიღი");
        entity.Property(e => e.GroupId).HasComment("ჯგუფი");
        entity.Property(e => e.HoursCount).HasDefaultValue(1f).HasComment("საათები");
        entity.Property(e => e.RoomId).HasComment("ოთახი");
        entity.Property(e => e.StartDate).HasDefaultValueSql("getdate()")
            .HasComment("გააქტიურების თარიღი");
        entity.Property(e => e.LessonStarTime).HasComment("გაკვეთილის დაწყების დრო");
        entity.Property(e => e.WeekDay).HasComment("კვირის დღე");

        entity.HasOne(d => d.GroupNavigation).WithMany(p => p.GroupDayTimePlace).HasForeignKey(d => d.GroupId)
            .OnDelete(DeleteBehavior.ClientSetNull);

        entity.HasOne(d => d.RoomNavigation).WithMany(p => p.GroupDayTimePlace).HasForeignKey(d => d.RoomId)
            .OnDelete(DeleteBehavior.ClientSetNull);

        entity.HasOne(d => d.LessonStartTimeNavigation).WithMany(p => p.GroupDayTimePlace)
            .HasForeignKey(d => d.LessonStarTime).OnDelete(DeleteBehavior.ClientSetNull);

        entity.HasOne(d => d.WeekDayNavigation).WithMany(p => p.GroupDayTimePlace).HasForeignKey(d => d.WeekDay)
            .OnDelete(DeleteBehavior.ClientSetNull);
    }
}
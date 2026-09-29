using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MimosiGeCore.Domain.Models;

namespace MimosiGeDbPart.Db.Configurations;

public sealed class GroupDayTimePlaceConfiguration : IEntityTypeConfiguration<GroupDayTimePlace>
{
    public void Configure(EntityTypeBuilder<GroupDayTimePlace> entity)
    {
        entity.ToTable("GroupDayTimePlaces",
            t => t.HasComment("ჯგუფის განრიგი: კვირის დღე, დაწყების დრო, საათები, ოთახი და მოქმედების პერიოდი"));
        entity.HasKey(e => e.GdtpId);

        entity.HasIndex(e => e.GroupId);

        entity.HasIndex(e => e.RoomId);

        entity.Property(e => e.GdtpId).HasComment("იდენტიფიკატორი");
        entity.Property(e => e.EndDate).HasComment("გაუქმების თარიღი");
        entity.Property(e => e.GroupId).HasComment("ჯგუფი");
        entity.Property(e => e.HoursCount).HasComment("საათები");
        entity.Property(e => e.LessonStartTimeId).HasComment("გაკვეთილის დაწყების დრო");
        entity.Property(e => e.RoomId).HasComment("ოთახი");
        entity.Property(e => e.StartDate).HasDefaultValueSql("CONVERT(date, getdate())")
            .HasComment("გააქტიურების თარიღი");
        entity.Property(e => e.WeekDayId).HasComment("კვირის დღე");

        entity.HasOne(d => d.Group).WithMany(p => p.GroupDayTimePlaces).HasForeignKey(d => d.GroupId)
            .OnDelete(DeleteBehavior.Restrict);

        entity.HasOne(d => d.Room).WithMany(p => p.GroupDayTimePlaces).HasForeignKey(d => d.RoomId)
            .OnDelete(DeleteBehavior.Restrict);

        entity.HasOne(d => d.LessonStartTime).WithMany(p => p.GroupDayTimePlaces)
            .HasForeignKey(d => d.LessonStartTimeId).OnDelete(DeleteBehavior.Restrict);

        entity.HasOne(d => d.WeekDay).WithMany(p => p.GroupDayTimePlaces).HasForeignKey(d => d.WeekDayId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}

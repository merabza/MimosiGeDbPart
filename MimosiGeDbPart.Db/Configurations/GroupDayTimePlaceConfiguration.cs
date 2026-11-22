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

        //ხაზი ერთ სტრიქონს ქმნის, ბრძანების შენახვა სტრიქონებს ამ კავშირით ადარებს (GROUP_ORDERS.md §5).
        //SQL Server-ზე EF ფილტრს (IS NOT NULL) თვითონ ამატებს
        entity.HasIndex(e => e.GroupOrderDayTimePlaceId).IsUnique();

        entity.Property(e => e.GdtpId).HasComment("იდენტიფიკატორი");
        entity.Property(e => e.EndDate).HasComment("გაუქმების თარიღი");
        entity.Property(e => e.GroupId).HasComment("ჯგუფი");
        entity.Property(e => e.HoursCount).HasComment("საათები");
        entity.Property(e => e.LessonStartTimeId).HasComment("გაკვეთილის დაწყების დრო");
        entity.Property(e => e.RoomId).HasComment("ოთახი");
        entity.Property(e => e.StartDate).HasDefaultValueSql("CONVERT(date, getdate())")
            .HasComment("გააქტიურების თარიღი");
        entity.Property(e => e.WeekDayId).HasComment("კვირის დღე");
        entity.Property(e => e.GroupOrderDayTimePlaceId)
            .HasComment("ბრძანების ხაზი, რომელმაც სტრიქონი შექმნა (ჯგუფების რეჟიმში ცარიელია)");

        entity.HasOne(d => d.Group).WithMany(p => p.GroupDayTimePlaces).HasForeignKey(d => d.GroupId)
            .OnDelete(DeleteBehavior.Restrict);

        //ხაზი არ იშლება, სანამ მისი სტრიქონი არსებობს (GROUP_ORDERS.md §10, A2)
        entity.HasOne(d => d.GroupOrderDayTimePlace).WithMany().HasForeignKey(d => d.GroupOrderDayTimePlaceId)
            .OnDelete(DeleteBehavior.Restrict);

        entity.HasOne(d => d.Room).WithMany(p => p.GroupDayTimePlaces).HasForeignKey(d => d.RoomId)
            .OnDelete(DeleteBehavior.Restrict);

        entity.HasOne(d => d.LessonStartTime).WithMany(p => p.GroupDayTimePlaces)
            .HasForeignKey(d => d.LessonStartTimeId).OnDelete(DeleteBehavior.Restrict);

        entity.HasOne(d => d.WeekDay).WithMany(p => p.GroupDayTimePlaces).HasForeignKey(d => d.WeekDayId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}

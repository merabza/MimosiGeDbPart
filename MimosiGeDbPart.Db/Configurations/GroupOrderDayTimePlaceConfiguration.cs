using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MimosiGeCore.Domain.Models;

namespace MimosiGeDbPart.Db.Configurations;

public sealed class GroupOrderDayTimePlaceConfiguration : IEntityTypeConfiguration<GroupOrderDayTimePlace>
{
    public void Configure(EntityTypeBuilder<GroupOrderDayTimePlace> builder)
    {
        builder.ToTable("GroupOrderDayTimePlaces",
            t => t.HasComment("ბრძანებების განრიგის ხაზები: კვირის დღე, დაწყების დრო, საათები და ოთახი"));
        builder.HasKey(e => e.Id);

        builder.Property(e => e.Id).HasComment("იდენტიფიკატორი");
        builder.Property(e => e.GroupOrderId).HasComment("ბრძანება");
        builder.Property(e => e.WeekDayId).HasComment("კვირის დღე");
        builder.Property(e => e.LessonStartTimeId).HasComment("გაკვეთილის დაწყების დრო");
        builder.Property(e => e.HoursCount).HasComment("საათები");
        builder.Property(e => e.RoomId).HasComment("ოთახი");
        builder.Property(e => e.StartDate).HasComment("გააქტიურების თარიღი (მხოლოდ საწყისი ბრძანება)");
        builder.Property(e => e.EndDate).HasComment("გაუქმების თარიღი (მხოლოდ საწყისი ბრძანება)");

        //ხაზი ბრძანების ნაწილია და მასთან ერთად იშლება
        builder.HasOne(d => d.GroupOrder).WithMany(p => p.GroupOrderDayTimePlaces).HasForeignKey(d => d.GroupOrderId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(d => d.LessonStartTime).WithMany().HasForeignKey(d => d.LessonStartTimeId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(d => d.Room).WithMany().HasForeignKey(d => d.RoomId).OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(d => d.WeekDay).WithMany().HasForeignKey(d => d.WeekDayId).OnDelete(DeleteBehavior.Restrict);
    }
}

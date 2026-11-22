using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MimosiGeCore.Domain.Models;

namespace MimosiGeDbPart.Db.Configurations;

public sealed class GroupOrderStudentConfiguration : IEntityTypeConfiguration<GroupOrderStudent>
{
    public void Configure(EntityTypeBuilder<GroupOrderStudent> builder)
    {
        builder.ToTable("GroupOrderStudents",
            t => t.HasComment("ბრძანებების მოსწავლის ხაზები: მოსწავლე, ტარიფი და შენიშვნა"));
        builder.HasKey(e => e.Id);

        builder.Property(e => e.Id).HasComment("იდენტიფიკატორი");
        builder.Property(e => e.GroupOrderId).HasComment("ბრძანება");
        builder.Property(e => e.StudentContractId).HasComment("მოსწავლე");
        builder.Property(e => e.FourWeekHours).HasComment("4 კვირაში საათების რაოდენობა (გაყვანისას ცარიელია)");
        builder.Property(e => e.FourWeekFee).HasComment("4 კვირაში გადასახადი (გაყვანისას ცარიელია)");
        builder.Property(e => e.OneHourFee).HasComment("ერთი საათის ღირებულება (გაყვანისას ცარიელია)");
        builder.Property(e => e.HoursCoefficient).HasComment("საათის კოეფიციენტი (გაყვანისას ცარიელია)");
        builder.Property(e => e.Note).HasMaxLength(255).HasComment("შენიშვნა");
        builder.Property(e => e.StartDate).HasComment("გააქტიურების თარიღი (მხოლოდ საწყისი ბრძანება)");
        builder.Property(e => e.EndDate).HasComment("გაუქმების თარიღი (მხოლოდ საწყისი ბრძანება)");

        //ხაზი ბრძანების ნაწილია და მასთან ერთად იშლება
        builder.HasOne(d => d.GroupOrder).WithMany(p => p.GroupOrderStudents).HasForeignKey(d => d.GroupOrderId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(d => d.StudentContract).WithMany().HasForeignKey(d => d.StudentContractId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}

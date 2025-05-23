using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MimosiGeDb.Models;

namespace MimosiGeDb.Configurations;

public sealed class GroupByStudentConfiguration : IEntityTypeConfiguration<GroupByStudent>
{
    public void Configure(EntityTypeBuilder<GroupByStudent> entity)
    {
        entity.HasKey(e => e.GbsId);

        entity.HasIndex(e => e.EndDate);

        entity.HasIndex(e => e.GroupId);

        entity.HasIndex(e => e.StartDate);

        entity.HasIndex(e => e.StudentContractId);

        entity.Property(e => e.GbsId);

        entity.Property(e => e.DirtyCharges).HasDefaultValue(true).HasComment("საჭიროებს დარიცხვების დაზუსტებას");
        entity.Property(e => e.EndDate).HasComment("გაუქმების თარიღი");
        entity.Property(e => e.FourWeekFee).HasDefaultValue(48m).HasComment("4 კვირაში გადასახადი")
            .HasColumnType("money");
        entity.Property(e => e.FourWeekHours).HasDefaultValue(8f).HasComment("4 კვირაში საათების რაოდენობა");
        entity.Property(e => e.GroupId).HasComment("ჯგუფი");
        entity.Property(e => e.HoursCoefficient).HasDefaultValue(1f).HasComment("საათის კოეფიციენტი");
        entity.Property(e => e.Note).HasMaxLength(255).HasComment("შენიშვნა");
        entity.Property(e => e.OneHourFee).HasDefaultValue(6m).HasComment("ერთი საათის ღირებულება")
            .HasColumnType("money");
        entity.Property(e => e.StartDate).HasDefaultValueSql("getdate()")
            .HasComment("გააქტიურების თარიღი");
        entity.Property(e => e.StudentContractId).HasComment("მოსწავლე");

        entity.HasOne(d => d.GroupNavigation).WithMany(p => p.GroupsByStudents).HasForeignKey(d => d.GroupId)
            .OnDelete(DeleteBehavior.ClientSetNull);
    }
}
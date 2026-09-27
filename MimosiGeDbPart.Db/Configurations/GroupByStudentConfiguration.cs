using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MimosiGeDbPart.Db.Models;

namespace MimosiGeDbPart.Db.Configurations;

public sealed class GroupByStudentConfiguration : IEntityTypeConfiguration<GroupByStudent>
{
    public void Configure(EntityTypeBuilder<GroupByStudent> entity)
    {
        entity.ToTable("GroupsByStudents", t =>
        {
            t.HasComment("მოსწავლეები ჯგუფებში: მონაწილეობის პერიოდი და ტარიფი");
            t.HasCheckConstraint("CK_GroupsByStudents_FourWeekHours", "[FourWeekHours] > 0");
            t.HasCheckConstraint("CK_GroupsByStudents_FourWeekFee", "[FourWeekFee] > 0");
            t.HasCheckConstraint("CK_GroupsByStudents_OneHourFee", "[OneHourFee] > 0");
            t.HasCheckConstraint("CK_GroupsByStudents_HoursCoefficient", "[HoursCoefficient] > 0");
        });
        entity.HasKey(e => e.GbsId);

        entity.HasIndex(e => e.EndDate);

        entity.HasIndex(e => e.GroupId);

        entity.HasIndex(e => e.StartDate);

        entity.HasIndex(e => e.StudentContractId);

        entity.Property(e => e.GbsId).HasComment("იდენტიფიკატორი");

        entity.Property(e => e.EndDate).HasComment("გაუქმების თარიღი");
        entity.Property(e => e.FourWeekFee).HasComment("4 კვირაში გადასახადი").HasColumnType("money");
        entity.Property(e => e.FourWeekHours).HasComment("4 კვირაში საათების რაოდენობა");
        entity.Property(e => e.GroupId).HasComment("ჯგუფი");
        entity.Property(e => e.HoursCoefficient).HasComment("საათის კოეფიციენტი");
        entity.Property(e => e.Note).HasMaxLength(255).HasComment("შენიშვნა");
        entity.Property(e => e.OneHourFee).HasComment("ერთი საათის ღირებულება").HasColumnType("money");
        entity.Property(e => e.StartDate).HasDefaultValueSql("CONVERT(date, getdate())")
            .HasComment("გააქტიურების თარიღი");
        entity.Property(e => e.StudentContractId).HasComment("მოსწავლე");

        entity.HasOne(d => d.Group).WithMany(p => p.GroupsByStudents).HasForeignKey(d => d.GroupId)
            .OnDelete(DeleteBehavior.Restrict);

        entity.HasOne(d => d.StudentContract).WithMany(p => p.GroupsByStudents).HasForeignKey(d => d.StudentContractId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}

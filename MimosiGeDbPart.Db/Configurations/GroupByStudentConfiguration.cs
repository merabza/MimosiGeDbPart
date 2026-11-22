using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MimosiGeCore.Domain.Models;

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

        //ხაზი ერთ სტრიქონს ქმნის, ბრძანების შენახვა სტრიქონებს ამ კავშირით ადარებს (GROUP_ORDERS.md §5).
        //SQL Server-ზე EF ფილტრს (IS NOT NULL) თვითონ ამატებს
        entity.HasIndex(e => e.GroupOrderStudentId).IsUnique();

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
        entity.Property(e => e.GroupOrderStudentId)
            .HasComment("ბრძანების ხაზი, რომელმაც სტრიქონი შექმნა (ჯგუფების რეჟიმში ცარიელია)");

        entity.HasOne(d => d.Group).WithMany(p => p.GroupsByStudents).HasForeignKey(d => d.GroupId)
            .OnDelete(DeleteBehavior.Restrict);

        //ხაზი არ იშლება, სანამ მისი სტრიქონი არსებობს (GROUP_ORDERS.md §10, A2)
        entity.HasOne(d => d.GroupOrderStudent).WithMany().HasForeignKey(d => d.GroupOrderStudentId)
            .OnDelete(DeleteBehavior.Restrict);

        entity.HasOne(d => d.StudentContract).WithMany(p => p.GroupsByStudents).HasForeignKey(d => d.StudentContractId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}

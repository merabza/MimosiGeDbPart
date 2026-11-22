using BackendCarcass.Database.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MimosiGeCore.Domain.Models;

namespace MimosiGeDbPart.Db.Configurations;

public sealed class GroupOrderConfiguration : IEntityTypeConfiguration<GroupOrder>
{
    public void Configure(EntityTypeBuilder<GroupOrder> builder)
    {
        builder.ToTable("GroupOrders",
            t => t.HasComment("ჯგუფების ბრძანებები: ბრძანებების რეჟიმში ჯგუფის ყოველი ცვლილება ბრძანებით კეთდება"));
        builder.HasKey(e => e.Id);

        //ნომერი არასოდეს მეორდება (D192); საწყის ბრძანებას ნომერი არ აქვს
        builder.HasIndex(e => new { e.NumberYear, e.Number }).IsUnique()
            .HasFilter("[NumberYear] IS NOT NULL AND [Number] IS NOT NULL");

        builder.Property(e => e.Id).HasComment("იდენტიფიკატორი");
        builder.Property(e => e.OrderType).HasComment(
            "ბრძანების ტიპი: 0 საწყისი მდგომარეობა, 1 ჯგუფის შექმნა, 2 მასწავლებლის შეცვლა, 3 მოსწავლეების დამატება, " +
            "4 მოსწავლეების გაყვანა, 5 მოსწავლეების გადაყვანა, 6 განრიგის შეცვლა, 7 ჯგუფის დახურვა, " +
            "8 მოსწავლის საფასურის შეცვლა, 9 მასწავლებლის ხელფასის სქემის შეცვლა, 10 კვირის საათების შეცვლა");
        builder.Property(e => e.AcademicYearId).HasComment("სასწავლო წელი (ჯგუფის წელი და ნომრის წელი)");
        builder.Property(e => e.NumberYear).HasComment("ნომრის წელი: სასწავლო წლის დაწყების წლის ბოლო ორი ციფრი");
        builder.Property(e => e.Number).HasComment("რიგითი ნომერი ნომრის წლის შიგნით");
        builder.Property(e => e.IssueDate).HasComment("გამოცემის თარიღი (პირველი შენახვის დღე)");
        builder.Property(e => e.OrderDate).HasComment("ბრძანების თარიღი: ცვლილება ამ დღიდან მოქმედებს");
        builder.Property(e => e.IsPaused).HasDefaultValue(false)
            .HasComment("დაპაუზებული შექმნის ბრძანება (ჯგუფი ჯერ არ შექმნილა)");
        builder.Property(e => e.GroupId).HasComment("ჯგუფი (გადაყვანისას საიდან)");
        builder.Property(e => e.TargetGroupId).HasComment("გადაყვანის სამიზნე ჯგუფი");
        builder.Property(e => e.GroupCode).HasMaxLength(5).HasComment("ჯგუფის კოდი (საწყისი და შექმნის ბრძანება)");
        builder.Property(e => e.CourseId).HasComment("საგანი (საწყისი და შექმნის ბრძანება)");
        builder.Property(e => e.GroupSizeId).HasComment("ჯგუფის ზომა (საწყისი და შექმნის ბრძანება)");
        builder.Property(e => e.StudentStatusId).HasComment("მოსწავლის სტატუსი (საწყისი და შექმნის ბრძანება)");
        builder.Property(e => e.VoidDate).HasComment("ჯგუფის გაუქმების თარიღი (მხოლოდ საწყისი ბრძანება)");
        builder.Property(e => e.OrganizationName).HasMaxLength(255)
            .HasComment("ორგანიზაცია (გამოცემისას კონფიგურაციიდან)");
        builder.Property(e => e.SignerTitle).HasMaxLength(255).HasComment("ხელმომწერის თანამდებობა");
        builder.Property(e => e.SignerName).HasMaxLength(255).HasComment("ხელმომწერის სახელი და გვარი");
        builder.Property(e => e.CreatedByUserName).HasMaxLength(UserConfiguration.UserNameMaxLength)
            .HasComment("შემქმნელი მომხმარებელი");
        builder.Property(e => e.CreatedAt).HasComment("შექმნის დრო");
        builder.Property(e => e.ChangedByUserName).HasMaxLength(UserConfiguration.UserNameMaxLength)
            .HasComment("ბოლოს შემცვლელი მომხმარებელი");
        builder.Property(e => e.ChangedAt).HasComment("ბოლო შეცვლის დრო");

        builder.HasOne(d => d.AcademicYear).WithMany().HasForeignKey(d => d.AcademicYearId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(d => d.Course).WithMany().HasForeignKey(d => d.CourseId).OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(d => d.Group).WithMany().HasForeignKey(d => d.GroupId).OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(d => d.GroupSize).WithMany().HasForeignKey(d => d.GroupSizeId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(d => d.StudentStatus).WithMany().HasForeignKey(d => d.StudentStatusId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(d => d.TargetGroup).WithMany().HasForeignKey(d => d.TargetGroupId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}

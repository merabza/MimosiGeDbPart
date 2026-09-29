using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MimosiGeCore.Domain.Models;

namespace MimosiGeDbPart.Db.Configurations;

public sealed class TeacherContractConfiguration : IEntityTypeConfiguration<TeacherContract>
{
    public void Configure(EntityTypeBuilder<TeacherContract> builder)
    {
        builder.ToTable("TeacherContracts",
            t => t.HasComment("თანამშრომლების (მასწავლებლების და ადმინისტრაციის) კონტრაქტები"));
        builder.HasKey(e => e.Id);

        builder.HasIndex(e => e.ContractNumber).IsUnique();

        builder.HasIndex(e => e.BankAccountCode);

        builder.Property(e => e.Id).HasComment("იდენტიფიკატორი");
        builder.Property(e => e.BankAccount).HasMaxLength(22).HasComment("ანგარიშის ნომერი");
        builder.Property(e => e.BankAccountCode).HasMaxLength(8).HasComment("ბანკის კოდი");
        builder.Property(e => e.ContractDate).HasComment("კონტრაქტის თარიღი");
        builder.Property(e => e.ContractEndDate).HasComment("კონტრაქტის დასრულების თარიღი");
        builder.Property(e => e.ContractNumber).HasMaxLength(6).HasComment("კონტრაქტის ნომერი");
        builder.Property(e => e.Description).HasMaxLength(255).HasComment("განაცემის შინაარსი (თუ ხელფასი არ არის)");
        builder.Property(e => e.FixedAmount).HasDefaultValue(0m)
            .HasComment("განაცემის ყოველთვიური ფიქსირებული რაოდენობა");
        builder.Property(e => e.IndEnt).HasDefaultValue(false).HasComment("ინდივიდუალური მეწარმე");
        builder.Property(e => e.Line).HasDefaultValue(0).HasComment("დროის ხაზი (რეპორტი r35)");
        builder.Property(e => e.NextMonth).HasDefaultValue(false).HasComment("განაცემი ეკუთვნის შემდეგ თვეს");
        builder.Property(e => e.PensionScheme).HasDefaultValue(false).HasComment("მონაწილეობს საპენსიო სქემაში");
        builder.Property(e => e.RsCountryId).HasComment("ქვეყანა (საგადასახადოსათვის)");
        builder.Property(e => e.RsQuoteTypeId).HasComment("განაცემის სახე (საგადასახადოსათვის)");
        builder.Property(e => e.SalarySchemaByHoursId)
            .HasComment("ხელფასის ძირითადი სქემა საათობრივი ანაზღაურებისათვის");
        builder.Property(e => e.TeacherHumanId).HasComment("მასწავლებელი");
        builder.Property(e => e.WorkHourGroupId).HasComment("სამუშაო საათების ჯგუფი");
        builder.Property(e => e.WorkHoursEnd).HasComment("სამუშაოს დასრულება (მნიშვნელოვანია მხოლოდ დრო)");
        builder.Property(e => e.WorkHoursStart).HasComment("სამუშაოს დაწყება (მნიშვნელოვანია მხოლოდ დრო)");

        builder.HasOne(d => d.RsCountry).WithMany(p => p.TeacherContracts).HasForeignKey(d => d.RsCountryId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(d => d.RsQuoteType).WithMany(p => p.TeacherContracts).HasForeignKey(d => d.RsQuoteTypeId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(d => d.SalarySchemaByHours).WithMany(p => p.TeacherContracts)
            .HasForeignKey(d => d.SalarySchemaByHoursId).OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(d => d.TeacherHuman).WithMany(p => p.TeacherContracts).HasForeignKey(d => d.TeacherHumanId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(d => d.WorkHourGroup).WithMany(p => p.TeacherContracts).HasForeignKey(d => d.WorkHourGroupId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}

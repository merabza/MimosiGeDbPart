using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MimosiGeDbPart.Db.Models;

namespace MimosiGeDbPart.Db.Configurations;

public sealed class PaymentConfiguration : IEntityTypeConfiguration<Payment>
{
    public void Configure(EntityTypeBuilder<Payment> builder)
    {
        builder.ToTable("Payments", t => t.HasComment("მოსწავლეების გადახდები"));
        builder.HasKey(e => e.Id);

        builder.HasIndex(e => e.PayDate);

        builder.Property(e => e.Id).HasComment("იდენტიფიკატორი");
        builder.Property(e => e.Amount).HasDefaultValue(0m).HasComment("გადახდილი თანხა");
        builder.Property(e => e.BankAccountId).HasComment("ბანკის ანგარიში, სადაც შეიტანეს თანხა");
        builder.Property(e => e.Checked).HasDefaultValue(false).HasComment("შემოწმებულია");
        builder.Property(e => e.Document).HasMaxLength(255).HasComment("დოკუმენტი");
        builder.Property(e => e.PayDate).HasDefaultValueSql("CONVERT(date, getdate())").HasComment("გადახდის თარიღი");
        builder.Property(e => e.StudentContractId).HasComment("კონტრაქტი");

        builder.HasOne(d => d.BankAccount).WithMany(p => p.Payments).HasForeignKey(d => d.BankAccountId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(d => d.StudentContract).WithMany(p => p.Payments).HasForeignKey(d => d.StudentContractId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}

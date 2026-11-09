using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MimosiGeCore.Domain.Models;

namespace MimosiGeDbPart.Db.Configurations;

public sealed class StudentPayerConfiguration : IEntityTypeConfiguration<StudentPayer>
{
    public void Configure(EntityTypeBuilder<StudentPayer> builder)
    {
        builder.ToTable("StudentPayers",
            t => t.HasComment("მოსწავლეების გადამხდელები, ბანკის ჩარიცხვების ხელით განაწილებიდან დასწავლილი"));
        builder.HasKey(e => e.Id);

        builder.HasIndex(e => e.StudentHumanId);
        builder.HasIndex(e => e.PersonalNumber);
        builder.HasIndex(e => e.AccountIban);

        builder.Property(e => e.Id).HasComment("იდენტიფიკატორი");
        builder.Property(e => e.StudentHumanId).HasComment("მოსწავლე");
        builder.Property(e => e.PersonalNumber).HasMaxLength(20).HasComment("გადამხდელის პირადი ნომერი");
        builder.Property(e => e.AccountIban).HasMaxLength(50).HasComment("გადამხდელის ანგარიში (IBAN)");
        builder.Property(e => e.PayerName).HasMaxLength(255).HasComment("გადამხდელის სახელი ბანკის ჩარიცხვიდან");

        builder.HasOne(d => d.StudentHuman).WithMany().HasForeignKey(d => d.StudentHumanId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}

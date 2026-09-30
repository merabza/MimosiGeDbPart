using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MimosiGeCore.Domain.Models;

namespace MimosiGeDbPart.Db.Configurations;

public sealed class StudentContractConfiguration : IEntityTypeConfiguration<StudentContract>
{
    public void Configure(EntityTypeBuilder<StudentContract> builder)
    {
        builder.ToTable("StudentContracts", t => t.HasComment("მოსწავლეების კონტრაქტები"));
        builder.HasKey(e => e.ScId);

        //კონტრაქტის ნომერი სასწავლო წლის ფარგლებში უნიკალურია. ინდექსი AcademicYearId-ის FK-საც ემსახურება
        builder.HasIndex(e => new { e.AcademicYearId, e.ContractNumber }).IsUnique();

        builder.HasIndex(e => e.PayerHumanId);

        builder.HasIndex(e => e.StudentHumanId);

        builder.HasIndex(e => e.StudentStatusId);

        builder.Property(e => e.ScId).HasComment("იდენტიფიკატორი");
        builder.Property(e => e.AcademicYearId).HasComment("სასწავლო წელი");
        builder.Property(e => e.ContractDate).HasComment("კონტრაქტის თარიღი");
        builder.Property(e => e.ContractNumber).HasMaxLength(5).HasComment("კონტრაქტის ნომერი");
        builder.Property(e => e.DesiredMonthlyPaymentDay).HasComment("გადახდის სასურველი დღე თვეში");
        builder.Property(e => e.DirtyNextPayDate).HasComment("შემდეგი გადახდის თარიღს სჭირდება გადაანგარიშება");
        builder.Property(e => e.NextPayDate).HasComment("შემდეგი გადახდის თარიღი");
        builder.Property(e => e.PayerHumanId).HasComment("გადამხდელი");
        builder.Property(e => e.StudentHumanId).HasComment("მოსწავლე");
        builder.Property(e => e.StudentStatusId).HasComment("მოსწავლის სტატუსი");

        builder.HasOne(d => d.AcademicYear).WithMany(p => p.StudentContracts).HasForeignKey(d => d.AcademicYearId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(d => d.PayerHuman).WithMany(p => p.StudentContractsForPayers).HasForeignKey(d => d.PayerHumanId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(d => d.StudentHuman).WithMany(p => p.StudentContractsForStudents)
            .HasForeignKey(d => d.StudentHumanId).OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(d => d.StudentStatus).WithMany(p => p.StudentContracts).HasForeignKey(d => d.StudentStatusId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}

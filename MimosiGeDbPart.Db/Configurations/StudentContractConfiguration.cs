using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MimosiGeDbPart.Db.Models;

namespace MimosiGeDbPart.Db.Configurations;

public sealed class StudentContractConfiguration : IEntityTypeConfiguration<StudentContract>
{
    public void Configure(EntityTypeBuilder<StudentContract> builder)
    {
        builder.HasKey(e => e.ScId);

        builder.HasIndex(e => e.ContractNumber).IsUnique();

        builder.HasIndex(e => e.ParentHumanId);

        builder.HasIndex(e => e.StudentHumanId);

        builder.HasIndex(e => e.StudentStatusId);

        builder.Property(e => e.AcademicYearId).HasComment("სასწავლო წელი");
        builder.Property(e => e.ContractDate).HasComment("კონტრაქტის თარიღი");
        builder.Property(e => e.ContractNumber).HasMaxLength(5).HasComment("კონტრაქტის ნომერი");
        builder.Property(e => e.DesiredMonthlyPaymentDay).HasComment("გადახდის სასურველი დღე თვეში");
        builder.Property(e => e.DirtyNextPayDate).HasDefaultValue(true)
            .HasComment("შემდეგი გადახდის თარიღს სჭირდება გადაანგარიშება");
        builder.Property(e => e.NextPayDate).HasComment("შემდეგი გადახდის თარიღი");
        builder.Property(e => e.ParentHumanId).HasComment("მშობელი");
        builder.Property(e => e.StudentHumanId).HasComment("მოსწავლე");
        builder.Property(e => e.StudentStatusId).HasComment("მოსწავლის სტატუსი");

        builder.HasOne(d => d.AcademicYearNavigation).WithMany(p => p.StudentContracts)
            .HasForeignKey(d => d.AcademicYearId).OnDelete(DeleteBehavior.ClientSetNull);

        builder.HasOne(d => d.ParentHumanNavigation).WithMany(p => p.StudentContractsForParents)
            .HasForeignKey(d => d.ParentHumanId).OnDelete(DeleteBehavior.ClientSetNull);

        builder.HasOne(d => d.StudentHumanNavigation).WithMany(p => p.StudentContractsForStudents)
            .HasForeignKey(d => d.StudentHumanId).OnDelete(DeleteBehavior.ClientSetNull);

        builder.HasOne(d => d.StudentStatusNavigation).WithMany(p => p.StudentContracts)
            .HasForeignKey(d => d.StudentStatusId);
    }
}

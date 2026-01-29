using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MimosiGeDb.Models;

namespace MimosiGeDb.Configurations;

public sealed class LessonConfiguration : IEntityTypeConfiguration<Lesson>
{
    public void Configure(EntityTypeBuilder<Lesson> builder)
    {
        builder.HasKey(e => e.Id);

        builder.HasIndex(e => e.GroupId);

        builder.HasIndex(e => e.SalarySchemaId);

        builder.HasIndex(e => e.SubstituteTeacherContractId);

        builder.HasIndex(e => e.TeacherContractId);

        builder.HasIndex(e => new { e.GroupId, e.LessonDt }).IsUnique();

        builder.Property(e => e.Id);
        builder.Property(e => e.FourWeekHours).HasComment("4 კვირაში საათების რაოდენობა");
        builder.Property(e => e.GroupId).HasComment("ჯგუფი");
        builder.Property(e => e.LessonDt).HasComment("ჩატარების თარიღი და დრო");
        builder.Property(e => e.Note).HasMaxLength(255).HasComment("შენიშვნა");
        builder.Property(e => e.RecoverDate).HasComment("აღდგენა");
        builder.Property(e => e.SalarySchemaId).HasComment("ხელფასის სქემა");
        builder.Property(e => e.Status).HasDefaultValue(1).HasComment("გაკვეთილის ჩატარების სტატუსი");
        builder.Property(e => e.SubstituteTeacherContractId).HasComment("შემცვლელი მასწავლებელი");
        builder.Property(e => e.TeacherContractId).HasComment("მასწავლებელი");
        builder.Property(e => e.TeacherLateMinutes).HasComment("მასწავლებელმა დაიგვიანა წუთები");
        builder.Property(e => e.TeoMaxDate).HasComment(
            "ჯგუფში დროების განაწილების მიხედვით თეორიულად მაქსიმალური თარიღი იმ თვისთვის, როცა ეს გაკვეთილი ჩატარდა");
        builder.Property(e => e.TeoMinDate).HasComment(
            "ჯგუფში დროების განაწილების მიხედვით თეორიულად მინმალური თარიღი იმ თვისთვის, როცა ეს გაკვეთილი ჩატარდა");

        builder.HasOne(d => d.GroupNavigation).WithMany(p => p.Lessons).HasForeignKey(d => d.GroupId)
            .OnDelete(DeleteBehavior.ClientSetNull);

        builder.HasOne(d => d.StatusNavigation).WithMany(p => p.Lessons).HasForeignKey(d => d.Status)
            .OnDelete(DeleteBehavior.ClientSetNull);

        builder.HasOne(d => d.SubstituteTeacherContract).WithMany(p => p.LessonsSubstituteTeacherContract)
            .HasForeignKey(d => d.SubstituteTeacherContractId);

        builder.HasOne(d => d.TeacherContract).WithMany(p => p.LessonsTeacherContract)
            .HasForeignKey(d => d.TeacherContractId).OnDelete(DeleteBehavior.ClientSetNull);
    }
}

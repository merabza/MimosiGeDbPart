using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MimosiGeDbPart.Db.Models;

namespace MimosiGeDbPart.Db.Configurations;

public sealed class LessonConfiguration : IEntityTypeConfiguration<Lesson>
{
    public void Configure(EntityTypeBuilder<Lesson> builder)
    {
        builder.ToTable("Lessons", t =>
        {
            t.HasComment("გაკვეთილები (იქმნება გენერატორით)");
            t.HasCheckConstraint("CK_Lessons_TeacherLateMinutes", "[TeacherLateMinutes] >= 0");
        });
        builder.HasKey(e => e.Id);

        builder.HasIndex(e => e.SalarySchemaId);

        builder.HasIndex(e => e.SubstituteTeacherContractId);

        builder.HasIndex(e => e.TeacherContractId);

        //ინდექსი GroupId-ის FK-საც ემსახურება
        builder.HasIndex(e => new { e.GroupId, e.LessonDt }).IsUnique();

        builder.Property(e => e.Id).HasComment("იდენტიფიკატორი");
        builder.Property(e => e.FourWeekHours).HasComment("4 კვირაში საათების რაოდენობა");
        builder.Property(e => e.GroupId).HasComment("ჯგუფი");
        builder.Property(e => e.LessonDt).HasComment("ჩატარების თარიღი და დრო");
        builder.Property(e => e.LessonStatusId).HasComment("გაკვეთილის ჩატარების სტატუსი");
        builder.Property(e => e.Note).HasMaxLength(255).HasComment("შენიშვნა");
        builder.Property(e => e.RecoverDate).HasComment("აღდგენა");
        builder.Property(e => e.SalarySchemaId).HasComment("ხელფასის სქემა");
        builder.Property(e => e.SubstituteTeacherContractId).HasComment("შემცვლელი მასწავლებელი");
        builder.Property(e => e.TeacherContractId).HasComment("მასწავლებელი");
        builder.Property(e => e.TeacherLateMinutes).HasDefaultValue(0).HasComment("მასწავლებელმა დაიგვიანა წუთები");
        builder.Property(e => e.TeoMaxDate).HasComment(
            "ჯგუფში დროების განაწილების მიხედვით თეორიულად მაქსიმალური თარიღი იმ თვისთვის, როცა ეს გაკვეთილი ჩატარდა");
        builder.Property(e => e.TeoMinDate).HasComment(
            "ჯგუფში დროების განაწილების მიხედვით თეორიულად მინიმალური თარიღი იმ თვისთვის, როცა ეს გაკვეთილი ჩატარდა");

        builder.HasOne(d => d.Group).WithMany(p => p.Lessons).HasForeignKey(d => d.GroupId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(d => d.LessonStatus).WithMany(p => p.Lessons).HasForeignKey(d => d.LessonStatusId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(d => d.SalaryScheme).WithMany(p => p.Lessons).HasForeignKey(d => d.SalarySchemaId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(d => d.SubstituteTeacherContract).WithMany(p => p.LessonsSubstituteTeacherContract)
            .HasForeignKey(d => d.SubstituteTeacherContractId).OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(d => d.TeacherContract).WithMany(p => p.LessonsTeacherContract)
            .HasForeignKey(d => d.TeacherContractId).OnDelete(DeleteBehavior.Restrict);
    }
}

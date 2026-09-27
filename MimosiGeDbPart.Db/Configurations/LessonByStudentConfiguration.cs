using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MimosiGeDbPart.Db.Models;

namespace MimosiGeDbPart.Db.Configurations;

public sealed class LessonByStudentConfiguration : IEntityTypeConfiguration<LessonByStudent>
{
    public void Configure(EntityTypeBuilder<LessonByStudent> builder)
    {
        builder.ToTable("LessonsByStudents", t =>
        {
            t.HasComment("მოსწავლეები გაკვეთილზე: დასწრება, საათები, შეფასება და კომენტარები");
            t.HasCheckConstraint("CK_LessonsByStudents_StudentLateMinutes", "[StudentLateMinutes] >= 0");
        });
        builder.HasKey(e => e.Id);

        builder.HasIndex(e => e.Present);

        builder.Property(e => e.Id).HasComment("იდენტიფიკატორი");
        builder.Property(e => e.GroupByStudentId).HasComment("მოსწავლე ჯგუფიდან");
        builder.Property(e => e.HoursCount).HasComment("საათების რაოდენობა");
        builder.Property(e => e.LessonId).HasComment("გაკვეთილი");
        builder.Property(e => e.Present).HasDefaultValue(false).HasComment("დაესწრო გაკვეთილს");
        builder.Property(e => e.Rate).HasComment("შეფასება");
        builder.Property(e => e.StudentComment).HasMaxLength(255).HasComment("მოსწავლის კომენტარი");
        builder.Property(e => e.StudentContractId).HasComment("მოსწავლე");
        builder.Property(e => e.StudentLateMinutes).HasDefaultValue(0).HasComment("მოსწავლემ დაიგვიანა წუთები");
        builder.Property(e => e.TeacherComment).HasMaxLength(255).HasComment("მასწავლებლის კომენტარი");
        builder.Property(e => e.Theme).HasMaxLength(255).HasComment("თემა");

        builder.HasOne(d => d.GroupByStudent).WithMany(p => p.LessonsByStudents).HasForeignKey(d => d.GroupByStudentId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(d => d.Lesson).WithMany(p => p.LessonsByStudents).HasForeignKey(d => d.LessonId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(d => d.StudentContract).WithMany(p => p.LessonsByStudents)
            .HasForeignKey(d => d.StudentContractId).OnDelete(DeleteBehavior.Restrict);
    }
}

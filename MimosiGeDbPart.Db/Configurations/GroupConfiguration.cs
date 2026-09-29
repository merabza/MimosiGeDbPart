using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MimosiGeCore.Domain.Models;

namespace MimosiGeDbPart.Db.Configurations;

public sealed class GroupConfiguration : IEntityTypeConfiguration<Group>
{
    public void Configure(EntityTypeBuilder<Group> builder)
    {
        builder.ToTable("Groups", t => t.HasComment("სასწავლო ჯგუფები"));
        builder.HasKey(e => e.GrpId);

        builder.HasIndex(e => e.CourseId);

        builder.HasIndex(e => e.GroupSizeId);

        //ჯგუფის კოდი სასწავლო წლის ფარგლებში უნიკალურია. ინდექსი AcademicYearId-ის FK-საც ემსახურება
        builder.HasIndex(e => new { e.AcademicYearId, e.GroupCode }).IsUnique();

        builder.HasIndex(e => e.StudentStatusId);

        builder.Property(e => e.GrpId).HasComment("იდენტიფიკატორი");
        builder.Property(e => e.AcademicYearId).HasComment("სასწავლო წელი");
        builder.Property(e => e.CourseId).HasComment("საგანი");
        builder.Property(e => e.DirtyLessons).HasComment("საჭიროებს გაკვეთილების დაზუსტებას");
        builder.Property(e => e.GroupCode).HasMaxLength(5).HasComment("ჯგუფის კოდი");
        builder.Property(e => e.GroupSizeId).HasComment("ჯგუფის ზომა (ტიპი)");
        builder.Property(e => e.StudentStatusId).HasComment("მოსწავლის სტატუსი");
        builder.Property(e => e.VoidDate).HasComment("გაუქმების თარიღი");

        builder.HasOne(d => d.AcademicYear).WithMany(p => p.Groups).HasForeignKey(d => d.AcademicYearId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(d => d.Course).WithMany(p => p.Groups).HasForeignKey(d => d.CourseId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(d => d.GroupSize).WithMany(p => p.Groups).HasForeignKey(d => d.GroupSizeId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(d => d.StudentStatus).WithMany(p => p.Groups).HasForeignKey(d => d.StudentStatusId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}

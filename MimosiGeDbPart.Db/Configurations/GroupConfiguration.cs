using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MimosiGeDbPart.Db.Models;

namespace MimosiGeDbPart.Db.Configurations;

public sealed class GroupConfiguration : IEntityTypeConfiguration<Group>
{
    public void Configure(EntityTypeBuilder<Group> builder)
    {
        builder.HasKey(e => e.GrpId);

        builder.HasIndex(e => e.CourseId);

        builder.HasIndex(e => e.GroupSizeId);

        builder.HasIndex(e => e.GroupCode).IsUnique();

        builder.HasIndex(e => e.StudentStatusId);

        builder.Property(e => e.GrpId);
        builder.Property(e => e.CourseId).HasComment("საგანი");
        builder.Property(e => e.DirtyLessons).HasDefaultValue(true).HasComment("საჭიროებს გაკვეთილების დაზუსტებას");
        builder.Property(e => e.GroupCode).HasMaxLength(5).HasComment("ჯგუფის კოდი");
        builder.Property(e => e.GroupSizeId).HasDefaultValue(2).HasComment("ჯგუფის ზომა (ტიპი)");
        builder.Property(e => e.StudentStatusId).HasComment("მოსწავლის სტატუსი");
        builder.Property(e => e.VoidDate).HasComment("გაუქმების თარიღი");

        builder.HasOne(d => d.CourseNavigation).WithMany(p => p.Groups).HasForeignKey(d => d.CourseId)
            .OnDelete(DeleteBehavior.ClientSetNull);

        builder.HasOne(d => d.GroupSizeNavigation).WithMany(p => p.Groups).HasForeignKey(d => d.GroupSizeId)
            .OnDelete(DeleteBehavior.ClientSetNull);

        builder.HasOne(d => d.StudentStatusNavigation).WithMany(p => p.Groups).HasForeignKey(d => d.StudentStatusId)
            .OnDelete(DeleteBehavior.ClientSetNull);
    }
}

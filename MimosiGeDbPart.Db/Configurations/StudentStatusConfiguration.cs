using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MimosiGeDbPart.Db.Models;

namespace MimosiGeDbPart.Db.Configurations;

public sealed class StudentStatusConfiguration : IEntityTypeConfiguration<StudentStatus>
{
    public void Configure(EntityTypeBuilder<StudentStatus> builder)
    {
        builder.ToTable("StudentStatuses", t => t.HasComment("მოსწავლის სტატუსები (კლასები)"));
        builder.HasKey(e => e.Id);

        builder.Property(e => e.Id).HasComment("იდენტიფიკატორი");
        builder.Property(e => e.Rate).HasDefaultValue(0).HasComment("დალაგების რიგი");
        builder.Property(e => e.StudentStatusName).HasMaxLength(255).HasComment("მოსწავლის სტატუსის სახელი");
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MimosiGeDbPart.Db.Models;

namespace MimosiGeDbPart.Db.Configurations;

public sealed class TeacherSalarySchemeConfiguration : IEntityTypeConfiguration<TeacherSalaryScheme>
{
    public void Configure(EntityTypeBuilder<TeacherSalaryScheme> builder)
    {
        builder.ToTable("TeacherSalarySchemes", t => t.HasComment("მასწავლებლების საათობრივი ხელფასის სქემები"));
        builder.HasKey(e => e.Id);

        builder.Property(e => e.Id).HasComment("იდენტიფიკატორი");
        builder.Property(e => e.HourSalaryGross).HasDefaultValue(0m).HasComment("საათობრივი ხელფასი დარიცხული");
        builder.Property(e => e.HourSalaryNet).HasDefaultValue(0m).HasComment("საათობრივი ხელფასი ხელზე");
        builder.Property(e => e.SchemaName).HasMaxLength(255).HasComment("სქემის სახელი");
    }
}

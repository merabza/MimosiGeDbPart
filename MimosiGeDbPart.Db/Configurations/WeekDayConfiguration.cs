using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MimosiGeCore.Domain.Models;

namespace MimosiGeDbPart.Db.Configurations;

public sealed class WeekDayConfiguration : IEntityTypeConfiguration<WeekDay>
{
    public void Configure(EntityTypeBuilder<WeekDay> builder)
    {
        builder.ToTable("WeekDays", t => t.HasComment("კვირის დღეები"));
        builder.HasKey(e => e.Id);
        builder.HasIndex(e => e.Name).IsUnique();

        builder.Property(e => e.Id).HasComment("იდენტიფიკატორი (1 = ორშაბათი … 7 = კვირა)");
        builder.Property(e => e.Name).HasMaxLength(255).HasComment("კვირის დღის სახელი");
        builder.Property(e => e.ShortName).HasMaxLength(5).HasComment("მოკლე სახელი (რეპორტების სვეტებისთვის)");
        builder.Property(e => e.WeekDayNumber).HasDefaultValue(0).HasComment("კვირის დღის ნომერი (1 = ორშაბათი)");
    }
}

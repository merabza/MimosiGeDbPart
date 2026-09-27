using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MimosiGeDbPart.Db.Models;

namespace MimosiGeDbPart.Db.Configurations;

public sealed class LessonStatusConfiguration : IEntityTypeConfiguration<LessonStatus>
{
    public void Configure(EntityTypeBuilder<LessonStatus> builder)
    {
        builder.ToTable("LessonStatuses", t => t.HasComment("გაკვეთილის ჩატარების სტატუსები"));
        builder.HasKey(e => e.Id);

        builder.Property(e => e.Id).HasComment(
            "იდენტიფიკატორი: 1 = არ გაუქმებულა, 2 = გაუქმდა, 3 = გაუქმდა მასწავლებლისგან დამოუკიდებელი მიზეზით");
        builder.Property(e => e.StatusName).HasMaxLength(255).HasComment("სტატუსის დასახელება");
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MimosiGeDbPart.Db.Models;

namespace MimosiGeDbPart.Db.Configurations;

public sealed record SalaryLineDetailConfiguration : IEntityTypeConfiguration<SalaryLineDetail>
{
    public void Configure(EntityTypeBuilder<SalaryLineDetail> entity)
    {
        entity.ToTable("SalaryLinesDetails", t => t.HasComment("ხელფასის სტრიქონის დეტალები ჯგუფების მიხედვით"));
        entity.HasKey(e => e.SadId);

        entity.HasIndex(e => e.GroupId);

        entity.HasIndex(e => e.SaId);

        entity.Property(e => e.SadId).HasComment("დეტალის იდენტიფიკატორი");
        entity.Property(e => e.GroupId).HasComment("ჯგუფი");
        entity.Property(e => e.SaId).HasComment("ხელფასის სტრიქონის იდენტიფიკატორი");
        entity.Property(e => e.SadAmount).HasDefaultValue(0m).HasComment("გადასარიცხი თანხა").HasColumnType("money");
        entity.Property(e => e.SadHourCost).HasDefaultValue(0m).HasComment("ერთი საათის ღირებულება")
            .HasColumnType("money");
        entity.Property(e => e.SadHoursCount).HasDefaultValue(0f).HasComment("საათების რაოდენობა");

        entity.HasOne(d => d.Group).WithMany(p => p.SalaryLinesDetails).HasForeignKey(d => d.GroupId)
            .OnDelete(DeleteBehavior.Restrict);

        entity.HasOne(d => d.SalaryLine).WithMany(p => p.SalaryLinesDetails).HasForeignKey(d => d.SaId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}

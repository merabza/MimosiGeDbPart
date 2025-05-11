using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MimosiGeDb.Models;

namespace MimosiGeDb.Configurations;

public sealed record SalaryLineDetailConfiguration : IEntityTypeConfiguration<SalaryLineDetail>
{
    public void Configure(EntityTypeBuilder<SalaryLineDetail> entity)
    {
        entity.HasKey(e => e.SadId);

        entity.HasIndex(e => e.GroupId);

        entity.HasIndex(e => e.SaId);

        entity.HasIndex(e => e.SadId);

        entity.Property(e => e.SadId).HasComment("სტრიქონის იდენტიფიკატორი");
        entity.Property(e => e.GroupId).HasComment("ჯგუფი");
        entity.Property(e => e.SaId).HasComment("სათაურის იდენტიფიკატორი");
        entity.Property(e => e.SadAmount).HasComment("გადასარიცხი თანხა").HasColumnType("money");
        entity.Property(e => e.SadHourCost).HasComment("ერთი საათის ღირებულება").HasColumnType("money");
        entity.Property(e => e.SadHoursCount).HasComment("საათების რაოდენობა");

        entity.HasOne(d => d.GroupNavigation).WithMany(p => p.SalaryLinesDetails).HasForeignKey(d => d.GroupId)
            .OnDelete(DeleteBehavior.ClientSetNull);

        entity.HasOne(d => d.Sa).WithMany(p => p.SalaryLinesDetails).HasForeignKey(d => d.SaId);
    }
}
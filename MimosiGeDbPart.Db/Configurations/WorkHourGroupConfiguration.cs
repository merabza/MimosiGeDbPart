using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MimosiGeDbPart.Db.Models;

namespace MimosiGeDbPart.Db.Configurations;

public sealed class WorkHourGroupConfiguration : IEntityTypeConfiguration<WorkHourGroup>
{
    public void Configure(EntityTypeBuilder<WorkHourGroup> entity)
    {
        entity.HasKey(e => e.WhgId);

        entity.HasIndex(e => e.WhgId);

        entity.HasIndex(e => e.WhgKey);

        entity.Property(e => e.WhgId).HasComment("იდენტიფიკატორი");
        entity.Property(e => e.WhgKey).HasMaxLength(255).HasComment("გასაღები");
        entity.Property(e => e.WhgName).HasMaxLength(255).HasComment("სახელი");
        entity.Property(e => e.WhgSalaryNet).HasDefaultValue(0m).HasComment("ჯგუფის ხელფასი").HasColumnType("money");
    }
}

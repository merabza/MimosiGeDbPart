using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MimosiGeDbPart.Db.Models;

namespace MimosiGeDbPart.Db.Configurations;

public sealed class OperationMonthConfiguration : IEntityTypeConfiguration<OperationMonth>
{
    public void Configure(EntityTypeBuilder<OperationMonth> builder)
    {
        builder.ToTable("OperationMonths", t => t.HasComment("სამუშაო თვეების კალენდარი (თვის პირველი დღე)"));
        builder.HasKey(e => e.Id);
        builder.HasIndex(e => e.MonthDate).IsUnique();

        builder.Property(e => e.Id).HasComment("იდენტიფიკატორი");
        builder.Property(e => e.MonthDate).HasComment("თვე (თვის პირველი დღე)");
    }
}

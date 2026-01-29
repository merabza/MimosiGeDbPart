using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MimosiGeDb.Models;

namespace MimosiGeDb.Configurations;

public sealed class SalaryHeaderConfiguration : IEntityTypeConfiguration<SalaryHeader>
{
    public void Configure(EntityTypeBuilder<SalaryHeader> entity)
    {
        entity.HasKey(e => e.ShId);

        entity.HasIndex(e => e.ShId);

        entity.Property(e => e.ShId);
        entity.Property(e => e.ShChargeDate).HasComment("დარიცხვის თარიღი");
        entity.Property(e => e.ShTransferDate).HasComment("გადარიცხვის თარიღი");
    }
}

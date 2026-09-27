using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MimosiGeDbPart.Db.Models;

namespace MimosiGeDbPart.Db.Configurations;

public sealed class SalaryHeaderConfiguration : IEntityTypeConfiguration<SalaryHeader>
{
    public void Configure(EntityTypeBuilder<SalaryHeader> entity)
    {
        entity.ToTable("SalaryHeaders", t => t.HasComment("ხელფასის უწყისები (სათაურები)"));
        entity.HasKey(e => e.ShId);

        entity.Property(e => e.ShId).HasComment("უწყისის იდენტიფიკატორი");
        entity.Property(e => e.ShChargeDate).HasComment("დარიცხვის თარიღი");
        entity.Property(e => e.ShTransferDate).HasComment("გადარიცხვის თარიღი");
    }
}

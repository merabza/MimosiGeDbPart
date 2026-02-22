using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MimosiGeDbPart.Db.Models;

namespace MimosiGeDbPart.Db.Configurations;

public sealed class CrmCallTypeConfiguration : IEntityTypeConfiguration<CrmCallType>
{
    public void Configure(EntityTypeBuilder<CrmCallType> builder)
    {
        builder.HasKey(e => e.CctId);
        builder.HasIndex(e => e.CallTypeName).IsUnique();

        builder.Property(e => e.CallTypeName).HasMaxLength(255);
    }
}

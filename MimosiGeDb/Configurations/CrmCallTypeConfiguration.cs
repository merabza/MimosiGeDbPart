using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MimosiGeDb.Models;

namespace MimosiGeDb.Configurations;

public sealed class CrmCallTypeConfiguration : IEntityTypeConfiguration<CrmCallType>
{
    public void Configure(EntityTypeBuilder<CrmCallType> builder)
    {
        builder.HasKey(e => e.CctId);

        builder.Property(e => e.CallTypeName).HasMaxLength(255);
    }
}
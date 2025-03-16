using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MimosiGeDb.Models;

namespace MimosiGeDb.Configurations;

public class CrmCallTypeConfiguration : IEntityTypeConfiguration<CrmCallType>
{
    public void Configure(EntityTypeBuilder<CrmCallType> builder)
    {
        builder.HasKey(e => e.Id);

        builder.Property(e => e.CallTypeName).HasMaxLength(255);
    }
}
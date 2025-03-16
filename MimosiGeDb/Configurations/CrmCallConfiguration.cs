using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MimosiGeDb.Models;

namespace MimosiGeDb.Configurations;

public class CrmCallConfiguration : IEntityTypeConfiguration<CrmCall>
{
    public void Configure(EntityTypeBuilder<CrmCall> builder)
    {
        builder.HasKey(e => e.Id);

        builder.Property(e => e.CallConv).HasMaxLength(512);
    }
}
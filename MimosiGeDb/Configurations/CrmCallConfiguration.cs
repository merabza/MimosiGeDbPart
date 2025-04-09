using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MimosiGeDb.Models;

namespace MimosiGeDb.Configurations;

public sealed class CrmCallConfiguration : IEntityTypeConfiguration<CrmCall>
{
    public void Configure(EntityTypeBuilder<CrmCall> builder)
    {
        builder.HasKey(e => e.CcId);

        builder.Property(e => e.CallConversation).HasMaxLength(512);
    }
}
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MimosiGeDb.Models;

namespace MimosiGeDb.Configurations;

public sealed class GroupMaterialConfiguration : IEntityTypeConfiguration<GroupMaterial>
{
    public void Configure(EntityTypeBuilder<GroupMaterial> builder)
    {
        builder.HasKey(e => e.GmtId);
    }
}
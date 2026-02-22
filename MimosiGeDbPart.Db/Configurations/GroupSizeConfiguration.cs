using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MimosiGeDbPart.Db.Models;

namespace MimosiGeDbPart.Db.Configurations;

public sealed class GroupSizeConfiguration : IEntityTypeConfiguration<GroupSize>
{
    public void Configure(EntityTypeBuilder<GroupSize> builder)
    {
        builder.HasKey(e => e.GrsId);

        builder.HasIndex(e => e.GrsSize).IsUnique();
        builder.HasIndex(e => e.GrsName).IsUnique();

        builder.Property(e => e.GrsSize);
        builder.Property(e => e.GrsName).HasMaxLength(25);
    }
}

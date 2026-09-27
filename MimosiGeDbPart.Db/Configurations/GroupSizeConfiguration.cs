using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MimosiGeDbPart.Db.Models;

namespace MimosiGeDbPart.Db.Configurations;

public sealed class GroupSizeConfiguration : IEntityTypeConfiguration<GroupSize>
{
    public void Configure(EntityTypeBuilder<GroupSize> builder)
    {
        builder.ToTable("GroupSizes", t => t.HasComment("ჯგუფის ზომები (ტიპები)"));
        builder.HasKey(e => e.GrsId);

        builder.HasIndex(e => e.GrsName).IsUnique();

        builder.Property(e => e.GrsId).HasComment("იდენტიფიკატორი");
        builder.Property(e => e.GrsSize).HasDefaultValue(0).HasComment("ადგილების რაოდენობა ჯგუფში");
        builder.Property(e => e.GrsName).HasMaxLength(255).HasComment("ჯგუფის ზომის დასახელება");
    }
}

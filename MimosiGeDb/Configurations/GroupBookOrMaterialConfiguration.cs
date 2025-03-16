using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MimosiGeDb.Models;

namespace MimosiGeDb.Configurations;

public class GroupBookOrMaterialConfiguration : IEntityTypeConfiguration<GroupBookOrMaterial>
{
    public void Configure(EntityTypeBuilder<GroupBookOrMaterial> builder)
    {
        builder.ToTable("GroupBooksAndMaterials");
        builder.HasKey(e => e.BmId);
    }
}
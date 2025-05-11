using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MimosiGeDb.Models;

namespace MimosiGeDb.Configurations;

public sealed class RsBeneficiaryCategoryConfiguration : IEntityTypeConfiguration<RsBeneficiaryCategory>
{
    public void Configure(EntityTypeBuilder<RsBeneficiaryCategory> entity)
    {
        entity.HasKey(e => e.RbfId);

        entity.HasIndex(e => e.RbfId);

        entity.Property(e => e.RbfId);
        entity.Property(e => e.RbfName).HasMaxLength(255);
    }
}
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MimosiGeCore.Domain.Models;

namespace MimosiGeDbPart.Db.Configurations;

public sealed class CrmCallTypeConfiguration : IEntityTypeConfiguration<CrmCallType>
{
    public void Configure(EntityTypeBuilder<CrmCallType> builder)
    {
        builder.ToTable("CrmCallTypes", t => t.HasComment("CRM ზარის მიზეზის ტიპები"));
        builder.HasKey(e => e.CctId);
        builder.HasIndex(e => e.CallTypeName).IsUnique();

        builder.Property(e => e.CctId).HasComment("იდენტიფიკატორი");
        builder.Property(e => e.CallTypeName).HasMaxLength(255).HasComment("დარეკვის მიზეზის დასახელება");
    }
}

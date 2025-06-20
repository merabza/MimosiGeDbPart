using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MimosiGeDb.Models;

namespace MimosiGeDb.Configurations;

public sealed class CrmAnswerTypeConfiguration : IEntityTypeConfiguration<CrmAnswerType>
{
    public void Configure(EntityTypeBuilder<CrmAnswerType> builder)
    {
        builder.HasKey(e => e.CatId);

        builder.HasIndex(e => e.CatKey).IsUnique();
        builder.HasIndex(e => e.AnswerTypeName).IsUnique();

        builder.Property(e => e.CatKey).HasMaxLength(50);
        builder.Property(e => e.AnswerTypeName).HasMaxLength(255);
    }
}
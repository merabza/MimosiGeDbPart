using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MimosiGeDb.Models;

namespace MimosiGeDb.Configurations;

public sealed record SalaryPartTypeConfiguration : IEntityTypeConfiguration<SalaryPartType>
{
    public void Configure(EntityTypeBuilder<SalaryPartType> entity)
    {
        entity.HasKey(e => e.SptId);

        entity.HasIndex(e => e.RsQuoteTypeId);

        entity.HasIndex(e => e.SptId);

        entity.Property(e => e.SptId);
        entity.Property(e => e.RsQuoteTypeId).HasDefaultValue(0).HasComment("განაცემის ტიპის იდენტიფიკატორი");
        entity.Property(e => e.SptCountPlaceId).HasComment("გამოთვლებში მონაწილეობის ადგილი");
        entity.Property(e => e.SptName).HasMaxLength(255).HasComment("სახელი");
    }
}
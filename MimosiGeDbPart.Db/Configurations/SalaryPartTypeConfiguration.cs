using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MimosiGeCore.Domain.Models;

namespace MimosiGeDbPart.Db.Configurations;

public sealed record SalaryPartTypeConfiguration : IEntityTypeConfiguration<SalaryPartType>
{
    public void Configure(EntityTypeBuilder<SalaryPartType> entity)
    {
        entity.ToTable("SalaryPartTypes", t => t.HasComment("ხელფასის მდგენელების ტიპები"));
        entity.HasKey(e => e.SptId);

        entity.HasIndex(e => e.RsQuoteTypeId);

        entity.HasIndex(e => e.SptCountPlaceId);

        entity.Property(e => e.SptId).HasComment("იდენტიფიკატორი");
        entity.Property(e => e.RsQuoteTypeId).HasComment("განაცემის ტიპის იდენტიფიკატორი");
        entity.Property(e => e.SptCountPlaceId)
            .HasComment("გამოთვლებში მონაწილეობის ადგილი: 1 = დანამატი, 2 = გამოქვითვა ხელზე ასაღებიდან");
        entity.Property(e => e.SptName).HasMaxLength(255).HasComment("სახელი");

        entity.HasOne(d => d.RsQuoteType).WithMany(p => p.SalaryPartTypes).HasForeignKey(d => d.RsQuoteTypeId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MimosiGeCore.Domain.Models;

namespace MimosiGeDbPart.Db.Configurations;

public sealed class RsQuoteTypeConfiguration : IEntityTypeConfiguration<RsQuoteType>
{
    public void Configure(EntityTypeBuilder<RsQuoteType> entity)
    {
        entity.ToTable("RsQuoteTypes", t => t.HasComment("განაცემის სახეები (შემოსავლების სამსახურის ცნობარი)"));
        entity.HasKey(e => e.QtId);
        entity.HasIndex(e => e.QtName).IsUnique();

        //QtId შემოსავლების სამსახურის კოდია (1 = ხელფასი ...) და დეკლარაციაში იწერება, ამიტომ identity არ არის
        entity.Property(e => e.QtId).ValueGeneratedNever()
            .HasComment("განაცემის სახის კოდი (შემოსავლების სამსახურის)");
        entity.Property(e => e.QtName).HasMaxLength(255).HasComment("განაცემის სახის დასახელება");
    }
}

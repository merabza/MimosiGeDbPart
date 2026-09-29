using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MimosiGeCore.Domain.Models;

namespace MimosiGeDbPart.Db.Configurations;

public sealed class CrmAnswerTypeConfiguration : IEntityTypeConfiguration<CrmAnswerType>
{
    public void Configure(EntityTypeBuilder<CrmAnswerType> builder)
    {
        builder.ToTable("CrmAnswerTypes", t => t.HasComment("CRM ზარის შედეგის (პასუხის) ტიპები"));
        builder.HasKey(e => e.CatId);

        builder.HasIndex(e => e.CatKey).IsUnique();
        builder.HasIndex(e => e.AnswerTypeName).IsUnique();

        builder.Property(e => e.CatId).HasComment("იდენტიფიკატორი");
        builder.Property(e => e.CatKey).HasMaxLength(50).HasComment("პასუხის ტიპის გასაღები");
        builder.Property(e => e.AnswerTypeName).HasMaxLength(255).HasComment("პასუხის ტიპის დასახელება");
    }
}

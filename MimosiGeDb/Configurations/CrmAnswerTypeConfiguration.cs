using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MimosiGeDb.Models;

namespace MimosiGeDb.Configurations;

public class CrmAnswerTypeConfiguration : IEntityTypeConfiguration<CrmAnswerType>
{
    public void Configure(EntityTypeBuilder<CrmAnswerType> builder)
    {
        builder.HasKey(e => e.Id);

        builder.Property(e => e.AnswerName).HasMaxLength(255);
    }
}
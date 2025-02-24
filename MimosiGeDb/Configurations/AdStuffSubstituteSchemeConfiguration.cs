using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MimosiGeDb.Models;

namespace MimosiGeDb.Configurations;

public class AdStuffSubstituteSchemeConfiguration : IEntityTypeConfiguration<AdStuffSubstituteScheme>
{
    public void Configure(EntityTypeBuilder<AdStuffSubstituteScheme> builder)
    {
        builder.HasKey(e => e.Id);
    }
}

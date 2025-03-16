using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MimosiGeDb.Models;

namespace MimosiGeDb.Configurations;

public class AdStuffSubstituteTimeConfiguration : IEntityTypeConfiguration<AdStuffSubstituteTime>
{
    public void Configure(EntityTypeBuilder<AdStuffSubstituteTime> builder)
    {
        builder.HasKey(e => e.Id);
    }
}
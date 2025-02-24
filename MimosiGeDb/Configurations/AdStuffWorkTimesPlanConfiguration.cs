using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MimosiGeDb.Models;

namespace MimosiGeDb.Configurations;

public class AdStuffWorkTimesPlanConfiguration : IEntityTypeConfiguration<AdStuffWorkTimesPlan>
{
    public void Configure(EntityTypeBuilder<AdStuffWorkTimesPlan> builder)
    {
        builder.HasKey(e => e.Id);
    }
}

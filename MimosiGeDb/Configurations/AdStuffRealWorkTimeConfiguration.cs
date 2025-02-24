using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MimosiGeDb.Models;

namespace MimosiGeDb.Configurations;

public class AdStuffRealWorkTimeConfiguration : IEntityTypeConfiguration<AdStuffRealWorkTime>
{
    public void Configure(EntityTypeBuilder<AdStuffRealWorkTime> builder)
    {
        builder.HasKey(e => e.Id);
    }
}
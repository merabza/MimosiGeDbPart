using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MimosiGeDb.Models;

namespace MimosiGeDb.Configurations;

public class ErrorLogTextConfiguration : IEntityTypeConfiguration<ErrorLogText>
{
    public void Configure(EntityTypeBuilder<ErrorLogText> builder)
    {
        builder.HasKey(e => e.Id);

        builder.Property(e => e.Text).HasMaxLength(255);
    }
}
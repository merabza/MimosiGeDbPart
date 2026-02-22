using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MimosiGeDbPart.Db.Models;

namespace MimosiGeDbPart.Db.Configurations;

public sealed class ErrorLogTextConfiguration : IEntityTypeConfiguration<ErrorLogText>
{
    public void Configure(EntityTypeBuilder<ErrorLogText> builder)
    {
        builder.HasKey(e => e.EltId);
        builder.HasIndex(e => e.Text).IsUnique();

        builder.Property(e => e.Text).HasMaxLength(255).HasComment("შეცდომის ტექსტი");
    }
}

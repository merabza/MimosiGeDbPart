using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MimosiGeDb.Models;

namespace MimosiGeDb.Configurations;

public sealed class HumanConfiguration : IEntityTypeConfiguration<Human>
{
    public void Configure(EntityTypeBuilder<Human> builder)
    {
        builder.HasKey(e => e.humId);
        builder.HasIndex(e => e.PersonalId).IsUnique();
        builder.Property(e => e.ActualAddress).HasMaxLength(255).HasComment("ფაქტიური მისამართი");
        builder.Property(e => e.BirthDate).HasComment("დაბადების თარიღი");
        builder.Property(e => e.Email).HasMaxLength(255);
        builder.Property(e => e.Employment).HasMaxLength(255).HasComment("დასაქმება");
        builder.Property(e => e.FirstName).HasMaxLength(255).HasComment("სახელი");
        builder.Property(e => e.LastName).HasMaxLength(255).HasComment("გვარი");
        builder.Property(e => e.LegalAddress).HasMaxLength(255).HasComment("იურიდიული მისამართი");
        builder.Property(e => e.LegalName).HasMaxLength(255).HasComment("ნამდვილი სახელი");
        builder.Property(e => e.PersonalId).HasMaxLength(11).HasComment("პირადი ნომერი");
        builder.Property(e => e.PhoneNumber).HasMaxLength(9).HasComment("ტელეფონის ნომერი");
    }
}
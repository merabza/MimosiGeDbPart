using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MimosiGeDb.Models;

namespace MimosiGeDb.Configurations;

public class BookOrMaterialConfiguration : IEntityTypeConfiguration<BookOrMaterial>
{
    public void Configure(EntityTypeBuilder<BookOrMaterial> builder)
    {
        builder.ToTable("BooksOrMaterials");

        builder.HasKey(e => e.Id);

        builder.Property(e => e.BmAuthors).HasMaxLength(255);
        builder.Property(e => e.BmName).HasMaxLength(255);
    }
}
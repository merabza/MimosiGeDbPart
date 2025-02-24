using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MimosiGeDb.Models;

namespace MimosiGeDb.Configurations;

public class BookOrMaterialTypeConfiguration : IEntityTypeConfiguration<BookOrMaterialType>
{
    public void Configure(EntityTypeBuilder<BookOrMaterialType> builder)
    {
        builder.ToTable("BookOrMaterialTypes");

        builder.HasKey(e => e.Id);

        builder.Property(e => e.BmtName).HasMaxLength(255);
    }
}

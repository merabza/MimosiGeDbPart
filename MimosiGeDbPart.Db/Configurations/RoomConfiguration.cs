using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MimosiGeCore.Domain.Models;

namespace MimosiGeDbPart.Db.Configurations;

public sealed class RoomConfiguration : IEntityTypeConfiguration<Room>
{
    public void Configure(EntityTypeBuilder<Room> builder)
    {
        builder.ToTable("Rooms", t => t.HasComment("ოთახები"));
        builder.HasKey(e => e.Id);
        builder.HasIndex(e => e.RoomName).IsUnique();

        builder.Property(e => e.Id).HasComment("იდენტიფიკატორი");
        builder.Property(e => e.RoomName).HasMaxLength(255).HasComment("ოთახის დასახელება");
    }
}

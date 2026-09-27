using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MimosiGeDbPart.Db.Models;

namespace MimosiGeDbPart.Db.Configurations;

public sealed class ReportConfiguration : IEntityTypeConfiguration<Report>
{
    public void Configure(EntityTypeBuilder<Report> builder)
    {
        builder.ToTable("Reports", t => t.HasComment("რეპორტები (უწყისები)"));
        builder.HasKey(e => e.Id);

        builder.Property(e => e.Id).HasComment("იდენტიფიკატორი");
        builder.Property(e => e.Description).HasMaxLength(255).HasComment("უწყისის სახელი");
        builder.Property(e => e.RepFltNames).HasMaxLength(255).HasComment("ფილტრები");
        builder.Property(e => e.ReportName).HasMaxLength(255).HasComment("უწყისის სახელი აქსესში");
    }
}

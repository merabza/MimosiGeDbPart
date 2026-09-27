using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MimosiGeDbPart.Db.Models;

namespace MimosiGeDbPart.Db.Configurations;

public sealed class ReportCategoryConfiguration : IEntityTypeConfiguration<ReportCategory>
{
    public void Configure(EntityTypeBuilder<ReportCategory> builder)
    {
        builder.ToTable("ReportCategories", t => t.HasComment("რეპორტების (უწყისების) კატეგორიები"));
        builder.HasKey(e => e.Id);

        builder.Property(e => e.Id).HasComment("იდენტიფიკატორი");
        builder.Property(e => e.ReportCategoryName).HasMaxLength(255).HasComment("უწყისის კატეგორიის სახელი");
    }
}

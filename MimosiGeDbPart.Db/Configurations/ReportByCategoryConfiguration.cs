using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MimosiGeDbPart.Db.Models;

namespace MimosiGeDbPart.Db.Configurations;

public sealed class ReportByCategoryConfiguration : IEntityTypeConfiguration<ReportByCategory>
{
    public void Configure(EntityTypeBuilder<ReportByCategory> builder)
    {
        builder.ToTable("ReportsByCategories", t => t.HasComment("რეპორტები კატეგორიების მიხედვით"));
        builder.HasKey(e => e.Id);

        builder.Property(e => e.Id).HasComment("იდენტიფიკატორი");
        builder.Property(e => e.ReportCategoryId).HasComment("უწყისის კატეგორია");
        builder.Property(e => e.ReportId).HasComment("უწყისი");

        builder.HasOne(d => d.Report).WithMany(p => p.ReportsByCategories).HasForeignKey(d => d.ReportId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(d => d.ReportCategory).WithMany(p => p.ReportsByCategories)
            .HasForeignKey(d => d.ReportCategoryId).OnDelete(DeleteBehavior.Restrict);
    }
}

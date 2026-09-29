using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MimosiGeCore.Domain.Models;

namespace MimosiGeDbPart.Db.Configurations;

public sealed record SalaryLineConfiguration : IEntityTypeConfiguration<SalaryLine>
{
    public void Configure(EntityTypeBuilder<SalaryLine> entity)
    {
        entity.ToTable("SalaryLines", t => t.HasComment("ხელფასის უწყისის სტრიქონები თანამშრომლების მიხედვით"));
        entity.HasKey(e => e.SaId);

        entity.HasIndex(e => e.TeacherContractId);

        entity.HasIndex(e => e.RsQuoteTypeId);

        entity.HasIndex(e => e.ShId);

        entity.Property(e => e.SaId).HasComment("სტრიქონის იდენტიფიკატორი");
        entity.Property(e => e.RsQuoteTypeId).HasComment("განაცემის სახე");
        entity.Property(e => e.SaAmountGross).HasDefaultValue(0m).HasComment("დარიცხული თანხა").HasColumnType("money");
        entity.Property(e => e.SaAmountNet).HasDefaultValue(0m).HasComment("გადასარიცხი თანხა").HasColumnType("money");
        entity.Property(e => e.SaGamokvitva).HasDefaultValue(0m).HasComment("გამოქვითვა").HasColumnType("money");
        entity.Property(e => e.SaGrossMinusPension).HasDefaultValue(0m).HasComment("დარიცხვას გამოკლებული საპენსიო")
            .HasColumnType("money");
        entity.Property(e => e.SaIncomeTax).HasDefaultValue(0m).HasComment("საშემოსავლო").HasColumnType("money");
        entity.Property(e => e.SaIndividualIncomeTax).HasDefaultValue(0m).HasComment("ინდივიდუალური საშემოსავლო")
            .HasColumnType("money");
        entity.Property(e => e.SaMonthDate).HasComment("დარიცხვის თვე");
        entity.Property(e => e.SaNetAmountRound).HasDefaultValue(0m)
            .HasComment("მთლიანი ნამუშევარი დამრგვალებული 2 ლარზე").HasColumnType("money");
        entity.Property(e => e.SaPension2).HasDefaultValue(0m).HasComment("საპენსიოს 2%").HasColumnType("money");
        entity.Property(e => e.SaPension4).HasDefaultValue(0m).HasComment("საპენსიოს 4% გადასარიცხი")
            .HasColumnType("money");
        entity.Property(e => e.ShId).HasComment("სათაურის იდენტიფიკატორი");
        entity.Property(e => e.TeacherContractId).HasComment("კონტრაქტის იდენტიფიკატორი");

        entity.HasOne(d => d.RsQuoteType).WithMany(p => p.SalaryLines).HasForeignKey(d => d.RsQuoteTypeId)
            .OnDelete(DeleteBehavior.Restrict);

        entity.HasOne(d => d.SalaryHeader).WithMany(p => p.SalaryLines).HasForeignKey(d => d.ShId)
            .OnDelete(DeleteBehavior.Restrict);

        entity.HasOne(d => d.TeacherContract).WithMany(p => p.SalaryLines).HasForeignKey(d => d.TeacherContractId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}

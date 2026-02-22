using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MimosiGeDbPart.Db.Models;

namespace MimosiGeDbPart.Db.Configurations;

public sealed record SalaryLineConfiguration : IEntityTypeConfiguration<SalaryLine>
{
    public void Configure(EntityTypeBuilder<SalaryLine> entity)
    {
        entity.HasKey(e => e.SaId);

        entity.HasIndex(e => e.TeacherContractId);

        entity.HasIndex(e => e.RsQuoteTypeId);

        entity.HasIndex(e => e.ShId);

        entity.HasIndex(e => e.SaId);

        entity.Property(e => e.SaId).HasComment("სტრიქონის იდენტიფიკატორი");
        entity.Property(e => e.RsQuoteTypeId).HasDefaultValue(1).HasComment("განაცემის სახე");
        entity.Property(e => e.SaAmountGross).HasComment("დარიცხული თანხა").HasColumnType("money");
        entity.Property(e => e.SaAmountNet).HasComment("გადასარიცხი თანხა").HasColumnType("money");
        entity.Property(e => e.SaGamokvitva).HasComment("გამოქვითვა").HasColumnType("money");
        entity.Property(e => e.SaGrossMinusPension).HasComment("დარიცხვას გამოკლებული საპენსიო").HasColumnType("money");
        entity.Property(e => e.SaIncomeTax).HasComment("საშემოსავლო").HasColumnType("money");
        entity.Property(e => e.SaIndividualIncomeTax).HasComment("ინდივიდუალური საშემოსავლო").HasColumnType("money");
        entity.Property(e => e.SaMonthDate).HasComment("დარიცხვის თვე");
        entity.Property(e => e.SaNetAmountRound).HasComment("მთლიანი ნამუშევარი დამრგვალებული 2 ლარზე")
            .HasColumnType("money");
        entity.Property(e => e.SaPension2).HasComment("საპენსიოს 2%").HasColumnType("money");
        entity.Property(e => e.SaPension4).HasComment("საპენსიოს 4% გადასარიცხი").HasColumnType("money");
        entity.Property(e => e.ShId).HasComment("სათაურის იდენტიფიკატორი");
        entity.Property(e => e.TeacherContractId).HasComment("კონტრაქტის იდენტიფიკატორი");

        entity.HasOne(d => d.RsQuoteType).WithMany(p => p.SalaryLines).HasForeignKey(d => d.RsQuoteTypeId);

        entity.HasOne(d => d.Sh).WithMany(p => p.SalaryLines).HasForeignKey(d => d.ShId)
            .OnDelete(DeleteBehavior.ClientSetNull);

        entity.HasOne(d => d.TeacherContract).WithMany(p => p.SalaryLines).HasForeignKey(d => d.TeacherContractId)
            .OnDelete(DeleteBehavior.ClientSetNull);
    }
}

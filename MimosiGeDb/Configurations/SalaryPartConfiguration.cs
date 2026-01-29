using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MimosiGeDb.Models;

namespace MimosiGeDb.Configurations;

public sealed record SalaryPartConfiguration : IEntityTypeConfiguration<SalaryPart>
{
    public void Configure(EntityTypeBuilder<SalaryPart> entity)
    {
        entity.HasKey(e => e.SpId);

        entity.HasIndex(e => e.TeacherContractId);

        entity.HasIndex(e => e.ShId);

        entity.HasIndex(e => e.SpId);

        entity.Property(e => e.SpId);
        entity.Property(e => e.ShId).HasComment("სათაურის იდენტიფიკატორი");
        entity.Property(e => e.SpAmount).HasDefaultValue(0m).HasComment("თანხა (მინუსი ნიშნავს გამოკლებას)")
            .HasColumnType("money");
        entity.Property(e => e.SpSalaryPartType).HasComment("ხელფასის მდგენელის ტიპი");
        entity.Property(e => e.TeacherContractId).HasComment("თანამშრომელი");

        entity.HasOne(d => d.Sh).WithMany(p => p.SalaryParts).HasForeignKey(d => d.ShId)
            .OnDelete(DeleteBehavior.ClientSetNull);

        entity.HasOne(d => d.SpSalaryPartTypeNavigation).WithMany(p => p.SalaryParts)
            .HasForeignKey(d => d.SpSalaryPartType);

        entity.HasOne(d => d.TeacherContract).WithMany(p => p.SalaryParts).HasForeignKey(d => d.TeacherContractId)
            .OnDelete(DeleteBehavior.ClientSetNull);
    }
}

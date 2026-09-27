using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MimosiGeDbPart.Db.Models;

namespace MimosiGeDbPart.Db.Configurations;

public sealed record SalaryPartConfiguration : IEntityTypeConfiguration<SalaryPart>
{
    public void Configure(EntityTypeBuilder<SalaryPart> entity)
    {
        entity.ToTable("SalaryParts", t => t.HasComment("ხელფასის მდგენელები (დანამატები და გამოქვითვები)"));
        entity.HasKey(e => e.SpId);

        entity.HasIndex(e => e.TeacherContractId);

        entity.HasIndex(e => e.ShId);

        entity.Property(e => e.SpId).HasComment("მდგენელის იდენტიფიკატორი");
        entity.Property(e => e.SalaryPartTypeId).HasComment("ხელფასის მდგენელის ტიპი");
        entity.Property(e => e.ShId).HasComment("სათაურის იდენტიფიკატორი");
        entity.Property(e => e.SpAmount).HasDefaultValue(0m).HasComment("თანხა (მინუსი ნიშნავს გამოკლებას)")
            .HasColumnType("money");
        entity.Property(e => e.TeacherContractId).HasComment("თანამშრომელი");

        entity.HasOne(d => d.SalaryHeader).WithMany(p => p.SalaryParts).HasForeignKey(d => d.ShId)
            .OnDelete(DeleteBehavior.Restrict);

        entity.HasOne(d => d.SalaryPartType).WithMany(p => p.SalaryParts).HasForeignKey(d => d.SalaryPartTypeId)
            .OnDelete(DeleteBehavior.Restrict);

        entity.HasOne(d => d.TeacherContract).WithMany(p => p.SalaryParts).HasForeignKey(d => d.TeacherContractId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MimosiGeCore.Domain.Models;

namespace MimosiGeDbPart.Db.Configurations;

public sealed class BankAccountConfiguration : IEntityTypeConfiguration<BankAccount>
{
    public void Configure(EntityTypeBuilder<BankAccount> builder)
    {
        builder.ToTable("BankAccounts",
            t => t.HasComment(
                "გადახდის სახეები: ბანკის ანგარიშები და სპეციალური სახეები (უიმედო ვალი, გაუქმება, ხელფასიდან, შარშანდელი, გადატანა)"));
        builder.HasKey(e => e.BaId);
        builder.HasIndex(e => e.BankCode).IsUnique();

        builder.Property(e => e.BaId).HasComment("იდენტიფიკატორი");
        builder.Property(e => e.AccountNumber).HasMaxLength(22).HasComment("ორგანიზაციის ანგარიშის ნომერი");
        builder.Property(e => e.BankCode).HasMaxLength(8).HasComment("ბანკის კოდი ან სპეციალური სახის კოდი");
        builder.Property(e => e.BankName).HasMaxLength(255).HasComment("გადახდის სახის (ბანკის) დასახელება");
        builder.Property(e => e.DesperateDebt).HasDefaultValue(false).HasComment("უიმედო ვალი");
    }
}

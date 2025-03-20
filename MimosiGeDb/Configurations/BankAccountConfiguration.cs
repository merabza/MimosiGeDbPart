using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MimosiGeDb.Models;

namespace MimosiGeDb.Configurations;

public class BankAccountConfiguration : IEntityTypeConfiguration<BankAccount>
{
    public void Configure(EntityTypeBuilder<BankAccount> builder)
    {
        builder.HasKey(e => e.BaId);
        builder.Property(e => e.AccountNumber).HasMaxLength(22);
        builder.Property(e => e.BankCode).HasMaxLength(8);
        builder.Property(e => e.BankName).HasMaxLength(255);
    }
}
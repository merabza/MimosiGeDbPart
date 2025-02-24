using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MimosiGeDb.Models;

namespace MimosiGeDb.Configurations;

public class AdStuffContractConfiguration : IEntityTypeConfiguration<AdStuffContract>
{
    public void Configure(EntityTypeBuilder<AdStuffContract> builder)
    {
        builder.HasKey(e => e.Id);

        builder.Property(e => e.BankAccount).HasMaxLength(22);
        builder.Property(e => e.BankAccountCode).HasMaxLength(8);
        builder.Property(e => e.ContractNumber).HasMaxLength(6);
        builder.Property(e => e.Description).HasMaxLength(255);
    }
}
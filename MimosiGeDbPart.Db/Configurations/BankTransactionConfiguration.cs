using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MimosiGeCore.Domain.Models;

namespace MimosiGeDbPart.Db.Configurations;

public sealed class BankTransactionConfiguration : IEntityTypeConfiguration<BankTransaction>
{
    public void Configure(EntityTypeBuilder<BankTransaction> builder)
    {
        builder.ToTable("BankTransactions",
            t => t.HasComment("ბანკიდან ინტეგრაციით მიღებული ჩარიცხვები (მოსწავლეებზე განაწილება გადახდებშია)"));
        builder.HasKey(e => e.Id);

        //ერთი მოძრაობა ერთხელ შემოდის
        builder.HasIndex(e => new { e.BankAccountId, e.MovementId }).IsUnique();
        builder.HasIndex(e => e.TransactionDate);

        builder.Property(e => e.Id).HasComment("იდენტიფიკატორი");
        builder.Property(e => e.BankAccountId).HasComment("ბანკის ანგარიში, რომელზეც ჩაირიცხა");
        builder.Property(e => e.MovementId).HasMaxLength(50).HasComment("ბანკის მოძრაობის უნიკალური იდენტიფიკატორი");
        builder.Property(e => e.TransactionDate).HasComment("ჩარიცხვის თარიღი");
        builder.Property(e => e.Amount).HasComment("ჩარიცხული თანხა");
        builder.Property(e => e.Currency).HasMaxLength(3).HasComment("ვალუტა");
        builder.Property(e => e.Purpose).HasMaxLength(500).HasComment("დანიშნულება");
        builder.Property(e => e.AdditionalInformation).HasMaxLength(500).HasComment("დამატებითი ინფორმაცია");
        builder.Property(e => e.AdditionalDescription).HasMaxLength(500).HasComment("დამატებითი აღწერა");
        builder.Property(e => e.DocumentNumber).HasMaxLength(50).HasComment("საბუთის ნომერი");
        builder.Property(e => e.PartnerName).HasMaxLength(255).HasComment("გადამხდელის სახელი");
        builder.Property(e => e.PartnerAccountIban).HasMaxLength(50).HasComment("გადამხდელის ანგარიში (IBAN)");
        builder.Property(e => e.PartnerBankCode).HasMaxLength(20).HasComment("გადამხდელის ბანკის კოდი");
        builder.Property(e => e.PartnerTaxCode).HasMaxLength(20)
            .HasComment("გადამხდელის საიდენტიფიკაციო კოდი ან პირადი ნომერი");
        builder.Property(e => e.PartnerPersonalNumber).HasMaxLength(20).HasComment("გადამხდელის პირადი ნომერი");
        builder.Property(e => e.ImportedAt).HasComment("ბანკიდან მიღების დრო");
        builder.Property(e => e.MatchStep).HasDefaultValue(0)
            .HasComment("რომელმა წესმა იპოვა მოსწავლე (0 = ვერ იპოვა)");
        builder.Property(e => e.AllocatedManually).HasDefaultValue(false)
            .HasComment("განაწილება მენეჯერმა ხელით გააკეთა ან შეცვალა");
        builder.Property(e => e.Ignored).HasDefaultValue(false)
            .HasComment("არ არის მოსწავლის გადახდა (არ ნაწილდება და რეპორტში არ ჩანს)");

        builder.HasOne(d => d.BankAccount).WithMany().HasForeignKey(d => d.BankAccountId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}

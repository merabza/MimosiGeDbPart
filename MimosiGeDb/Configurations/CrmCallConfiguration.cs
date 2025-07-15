using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MimosiGeDb.Models;

namespace MimosiGeDb.Configurations;

public sealed class CrmCallConfiguration : IEntityTypeConfiguration<CrmCall>
{
    public void Configure(EntityTypeBuilder<CrmCall> entity)
    {
        entity.HasKey(e => e.CcId);
        entity.HasIndex(e => e.StudentContractId);

        entity.Property(e => e.CcId);
        entity.Property(e => e.AnswerTypeId).HasComment("შედეგი");
        entity.Property(e => e.CallConversation).HasComment("საუბრის შინაარსი").HasMaxLength(512);
        entity.Property(e => e.CallDate).HasPrecision(0).HasDefaultValueSql("(getdate())").HasComment("თარიღი");
        entity.Property(e => e.CallTypeId).HasDefaultValue(1).HasComment("დარეკვის მიზეზი");
        entity.Property(e => e.MustPayDate).HasPrecision(0).HasComment("უნდა გადაიხადოს თარიღამდე");
        entity.Property(e => e.StudentContractId).HasComment("მოსწავლე");

        entity.HasOne(d => d.AnswerTypeNavigation).WithMany(p => p.CrmCalls).HasForeignKey(d => d.AnswerTypeId);
        entity.HasOne(d => d.CallTypeNavigation).WithMany(p => p.CrmCalls).HasForeignKey(d => d.CallTypeId);
        entity.HasOne(d => d.StudentContractNavigation).WithMany(p => p.CrmCalls)
            .HasForeignKey(d => d.StudentContractId);
    }
}
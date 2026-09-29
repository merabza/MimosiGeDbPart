using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MimosiGeCore.Domain.Models;

namespace MimosiGeDbPart.Db.Configurations;

public sealed class CrmCallConfiguration : IEntityTypeConfiguration<CrmCall>
{
    public void Configure(EntityTypeBuilder<CrmCall> entity)
    {
        entity.ToTable("CrmCalls", t => t.HasComment("CRM ზარები მოსწავლეების ოჯახებთან"));
        entity.HasKey(e => e.CcId);
        entity.HasIndex(e => e.StudentContractId);

        entity.Property(e => e.CcId).HasComment("იდენტიფიკატორი");
        entity.Property(e => e.AnswerTypeId).HasComment("შედეგი");
        //განზრახ nvarchar(max): Access-ში Memo იყო
        entity.Property(e => e.CallConversation).HasComment("საუბრის შინაარსი");
        entity.Property(e => e.CallDate).HasDefaultValueSql("getdate()").HasComment("დარეკვის თარიღი და დრო");
        entity.Property(e => e.CallTypeId).HasComment("დარეკვის მიზეზი");
        entity.Property(e => e.MustPayDate).HasComment("უნდა გადაიხადოს თარიღამდე");
        entity.Property(e => e.StudentContractId).HasComment("მოსწავლე");

        entity.HasOne(d => d.AnswerType).WithMany(p => p.CrmCalls).HasForeignKey(d => d.AnswerTypeId)
            .OnDelete(DeleteBehavior.Restrict);

        entity.HasOne(d => d.CallType).WithMany(p => p.CrmCalls).HasForeignKey(d => d.CallTypeId)
            .OnDelete(DeleteBehavior.Restrict);

        entity.HasOne(d => d.StudentContract).WithMany(p => p.CrmCalls).HasForeignKey(d => d.StudentContractId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}

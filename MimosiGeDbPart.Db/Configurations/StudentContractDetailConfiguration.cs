using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MimosiGeCore.Domain.Models;

namespace MimosiGeDbPart.Db.Configurations;

public sealed class StudentContractDetailConfiguration : IEntityTypeConfiguration<StudentContractDetail>
{
    public void Configure(EntityTypeBuilder<StudentContractDetail> builder)
    {
        builder.ToTable("StudentContractDetails",
            t => t.HasComment("მოსწავლის კონტრაქტის დეტალები: საგანი, ჯგუფის ზომა და ტარიფი"));
        builder.HasKey(e => e.Id);

        builder.Property(e => e.Id).HasComment("იდენტიფიკატორი");
        builder.Property(e => e.CourseId).HasComment("საგანი");
        builder.Property(e => e.FourWeekFee).HasComment("4 კვირაში გადასახადი");
        builder.Property(e => e.FourWeekHours).HasComment("4 კვირაში საათების რაოდენობა");
        builder.Property(e => e.GroupSizeId).HasComment("ჯგუფის ზომა (ტიპი)");
        builder.Property(e => e.OneHourFee).HasComment("ერთი საათის ღირებულება");
        builder.Property(e => e.StudentContractId).HasComment("მოსწავლის კონტრაქტი");

        builder.HasOne(d => d.Course).WithMany(p => p.StudentContractDetails).HasForeignKey(d => d.CourseId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(d => d.GroupSize).WithMany(p => p.StudentContractDetails).HasForeignKey(d => d.GroupSizeId)
            .OnDelete(DeleteBehavior.Restrict);

        //დეტალები კონტრაქტის ნაწილია და მასთან ერთად იშლება (Access-შიც Cascade იყო)
        builder.HasOne(d => d.StudentContract).WithMany(p => p.StudentContractDetails)
            .HasForeignKey(d => d.StudentContractId).OnDelete(DeleteBehavior.Cascade);
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MimosiGeCore.Domain.Models;

namespace MimosiGeDbPart.Db.Configurations;

public sealed class GroupOrderTeacherConfiguration : IEntityTypeConfiguration<GroupOrderTeacher>
{
    public void Configure(EntityTypeBuilder<GroupOrderTeacher> builder)
    {
        builder.ToTable("GroupOrderTeachers",
            t => t.HasComment("ბრძანებების მასწავლებლის ხაზები: მასწავლებელი და ხელფასის სქემა"));
        builder.HasKey(e => e.Id);

        builder.Property(e => e.Id).HasComment("იდენტიფიკატორი");
        builder.Property(e => e.GroupOrderId).HasComment("ბრძანება");
        builder.Property(e => e.TeacherContractId).HasComment("მასწავლებელი");
        builder.Property(e => e.SalarySchemaId).HasComment("ხელფასის სქემა");
        builder.Property(e => e.StartDate).HasComment("გააქტიურების თარიღი (მხოლოდ საწყისი ბრძანება)");
        builder.Property(e => e.EndDate).HasComment("გაუქმების თარიღი (მხოლოდ საწყისი ბრძანება)");

        //ხაზი ბრძანების ნაწილია და მასთან ერთად იშლება
        builder.HasOne(d => d.GroupOrder).WithMany(p => p.GroupOrderTeachers).HasForeignKey(d => d.GroupOrderId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(d => d.SalaryScheme).WithMany().HasForeignKey(d => d.SalarySchemaId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(d => d.TeacherContract).WithMany().HasForeignKey(d => d.TeacherContractId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}

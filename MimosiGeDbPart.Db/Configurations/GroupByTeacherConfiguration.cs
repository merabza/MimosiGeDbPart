using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MimosiGeCore.Domain.Models;

namespace MimosiGeDbPart.Db.Configurations;

public sealed class GroupByTeacherConfiguration : IEntityTypeConfiguration<GroupByTeacher>
{
    public void Configure(EntityTypeBuilder<GroupByTeacher> builder)
    {
        builder.ToTable("GroupsByTeachers",
            t => t.HasComment("მასწავლებლები ჯგუფებში: მუშაობის პერიოდი და ხელფასის სქემა"));
        builder.HasKey(e => e.Id);

        //ხაზი ერთ სტრიქონს ქმნის, ბრძანების შენახვა სტრიქონებს ამ კავშირით ადარებს (GROUP_ORDERS.md §5).
        //SQL Server-ზე EF ფილტრს (IS NOT NULL) თვითონ ამატებს
        builder.HasIndex(e => e.GroupOrderTeacherId).IsUnique();

        builder.Property(e => e.Id).HasComment("იდენტიფიკატორი");
        builder.Property(e => e.EndDate).HasComment("გაუქმების თარიღი");
        builder.Property(e => e.GroupId).HasComment("ჯგუფი");
        builder.Property(e => e.SalarySchemaId).HasComment("ხელფასის სქემა");
        builder.Property(e => e.StartDate).HasDefaultValueSql("CONVERT(date, getdate())")
            .HasComment("გააქტიურების თარიღი");
        builder.Property(e => e.TeacherContractId).HasComment("მასწავლებელი");
        builder.Property(e => e.GroupOrderTeacherId)
            .HasComment("ბრძანების ხაზი, რომელმაც სტრიქონი შექმნა (ჯგუფების რეჟიმში ცარიელია)");

        builder.HasOne(d => d.Group).WithMany(p => p.GroupsByTeachers).HasForeignKey(d => d.GroupId)
            .OnDelete(DeleteBehavior.Restrict);

        //ხაზი არ იშლება, სანამ მისი სტრიქონი არსებობს (GROUP_ORDERS.md §10, A2)
        builder.HasOne(d => d.GroupOrderTeacher).WithMany().HasForeignKey(d => d.GroupOrderTeacherId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(d => d.SalaryScheme).WithMany(p => p.GroupsByTeachers).HasForeignKey(d => d.SalarySchemaId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(d => d.TeacherContract).WithMany(p => p.GroupsByTeachers).HasForeignKey(d => d.TeacherContractId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}

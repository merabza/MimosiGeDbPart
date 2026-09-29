using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MimosiGeCore.Domain.Models;

namespace MimosiGeDbPart.Db.Configurations;

public sealed class WorkHourConfiguration : IEntityTypeConfiguration<WorkHour>
{
    public void Configure(EntityTypeBuilder<WorkHour> entity)
    {
        entity.ToTable("WorkHours", t => t.HasComment("თანამშრომლების ნამუშევარი დრო"));
        entity.HasKey(e => e.WhId);

        //ინდექსი TeacherContractId-ის FK-საც ემსახურება
        entity.HasIndex(e => new { e.TeacherContractId, e.WhStart, e.WhEnd });

        entity.Property(e => e.WhId).HasComment("იდენტიფიკატორი");
        entity.Property(e => e.TeacherContractId).HasComment("თანამშრომელი");
        entity.Property(e => e.WhEnd).HasComment("მუშაობის დასრულების თარიღი და დრო");
        entity.Property(e => e.WhStart).HasComment("მუშაობის დაწყების თარიღი და დრო");

        entity.HasOne(d => d.TeacherContract).WithMany(p => p.WorkHours).HasForeignKey(d => d.TeacherContractId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}

using System.Globalization;
using BackendCarcass.Database.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MimosiGeCore.Domain.Models;

namespace MimosiGeDbPart.Db.Configurations;

public sealed class GroupOrdersModeConfiguration : IEntityTypeConfiguration<GroupOrdersMode>
{
    public void Configure(EntityTypeBuilder<GroupOrdersMode> builder)
    {
        builder.ToTable("GroupOrdersMode", t =>
        {
            t.HasComment("პროგრამის რეჟიმი, ჯგუფების ან ბრძანებების: ერთი სტრიქონი; მისი არქონა ჯგუფების რეჟიმია");
            t.HasCheckConstraint("CK_GroupOrdersMode_SingleRow",
                string.Create(CultureInfo.InvariantCulture, $"[Id] = {GroupOrdersMode.SingleRowId}"));
        });
        builder.HasKey(e => e.Id);

        builder.Property(e => e.Id).ValueGeneratedNever().HasComment("იდენტიფიკატორი (ერთადერთი სტრიქონი)");
        builder.Property(e => e.IsOrdersMode).HasDefaultValue(false)
            .HasComment("ბრძანებების რეჟიმი: ჯგუფი მხოლოდ ბრძანებით იცვლება");
        builder.Property(e => e.TransitionDate).HasComment("ბრძანებებზე გადასვლის დღე (D0)");
        builder.Property(e => e.SwitchedByUserName).HasMaxLength(UserConfiguration.UserNameMaxLength)
            .HasComment("მომხმარებელი, რომელმაც რეჟიმი ბოლოს გადართო");
        //ვიზარდების ერთდროული გაშვებისას მეორე მთლიანად უარყოფილია (DbUpdateConcurrencyException, D221): ყოველი
        //გადართვა ამ დროს ცვლის. ბაზის სქემას ეს არ ცვლის
        builder.Property(e => e.SwitchedAt).IsConcurrencyToken().HasComment("რეჟიმის ბოლო გადართვის დრო");
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MimosiGeCore.Domain.Models;

namespace MimosiGeDbPart.Db.Configurations;

public sealed class GroupOrderNumberConfiguration : IEntityTypeConfiguration<GroupOrderNumber>
{
    public void Configure(EntityTypeBuilder<GroupOrderNumber> builder)
    {
        builder.ToTable("GroupOrderNumbers", t => t.HasComment("ბრძანებების ნომრების მთვლელი ნომრის წლების მიხედვით"));
        builder.HasKey(e => e.NumberYear);

        builder.Property(e => e.NumberYear).ValueGeneratedNever()
            .HasComment("ნომრის წელი: სასწავლო წლის დაწყების წლის ბოლო ორი ციფრი");
        //ერთდროული შენახვისას ერთი ნომერი ორჯერ არ გაიცემა: თუ მთვლელი სხვამ უკვე შეცვალა, SaveChanges უარყოფილია
        //(DbUpdateConcurrencyException). ბაზის სქემას ეს არ ცვლის
        builder.Property(e => e.LastNumber).IsConcurrencyToken().HasComment("ბოლოს გაცემული ნომერი");
    }
}

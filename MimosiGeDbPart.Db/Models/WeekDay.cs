using System.Collections.Generic;

namespace MimosiGeDbPart.Db.Models;

public sealed class WeekDay
{
    public int Id { get; set; }

    public required string Name { get; set; }

    public required string ShortName { get; set; }

    public int WeekDeyNom { get; set; }

    public ICollection<GroupDayTimePlace> GroupDayTimePlace { get; set; } = new List<GroupDayTimePlace>();
}

using System.Collections.Generic;

namespace MimosiGeDb.Models;

public class WeekDay
{
    public int Id { get; set; }

    public required string Name { get; set; }

    public required string ShortName { get; set; }

    public int WeekDeyNom { get; set; }

    public virtual ICollection<GroupDayTimePlace> GroupDayTimePlace { get; set; } = new List<GroupDayTimePlace>();
}
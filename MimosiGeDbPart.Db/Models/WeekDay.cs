using System.Collections.Generic;

namespace MimosiGeDbPart.Db.Models;

public sealed class WeekDay
{
    public int Id { get; set; }

    public required string Name { get; set; }

    public required string ShortName { get; set; }

    /// <summary>
    ///     კვირის დღის ნომერი (1 = ორშაბათი)
    /// </summary>
    public int WeekDayNumber { get; set; }

    public ICollection<GroupDayTimePlace> GroupDayTimePlaces { get; set; } = new List<GroupDayTimePlace>();
}

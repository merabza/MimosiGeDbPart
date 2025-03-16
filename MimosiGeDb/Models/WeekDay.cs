using System.Collections.Generic;

namespace MimosiGeDb.Models;

public class WeekDay
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? ShortName { get; set; }

    public float? WeekDeyNom { get; set; }

    public virtual ICollection<AdStuffSubstituteScheme> AdStuffSubstituteScheme { get; set; } =
        new List<AdStuffSubstituteScheme>();

    public virtual ICollection<GroupDayTimePlace> GroupDayTimePlace { get; set; } = new List<GroupDayTimePlace>();
}
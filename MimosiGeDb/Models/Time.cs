using System;
using System.Collections.Generic;

namespace MimosiGeDb.Models;

public sealed class Time
{
    public DateTime Tmid { get; set; }

    public ICollection<GroupDayTimePlace> GroupDayTimePlace { get; set; } = new List<GroupDayTimePlace>();
}
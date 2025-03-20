using System;
using System.Collections.Generic;

namespace MimosiGeDb.Models;

public class Time
{
    public DateTime Tmid { get; set; }

    public virtual ICollection<GroupDayTimePlace> GroupDayTimePlace { get; set; } = new List<GroupDayTimePlace>();
}
using System;
using System.Collections.Generic;

namespace MimosiGeDb.Models;

public sealed class LessonStartTime
{
    public DateTime Lstid { get; set; }

    public ICollection<GroupDayTimePlace> GroupDayTimePlace { get; set; } = new List<GroupDayTimePlace>();
}
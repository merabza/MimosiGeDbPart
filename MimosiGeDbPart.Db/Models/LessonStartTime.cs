using System;
using System.Collections.Generic;

namespace MimosiGeDbPart.Db.Models;

public sealed class LessonStartTime
{
    public int LstId { get; set; }

    /// <summary>
    ///     გაკვეთილის დაწყების დრო
    /// </summary>
    public TimeOnly LstTime { get; set; }

    public ICollection<GroupDayTimePlace> GroupDayTimePlaces { get; set; } = new List<GroupDayTimePlace>();
}

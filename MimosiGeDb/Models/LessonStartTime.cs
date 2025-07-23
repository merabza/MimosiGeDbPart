﻿using System;
using System.Collections.Generic;

namespace MimosiGeDb.Models;

public sealed class LessonStartTime
{
    public int LstId { get; set; }
    public DateTime LstTime { get; set; }

    public ICollection<GroupDayTimePlace> GroupDayTimePlaces { get; set; } = new List<GroupDayTimePlace>();
}
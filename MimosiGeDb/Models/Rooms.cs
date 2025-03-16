﻿using System.Collections.Generic;

namespace MimosiGeDb.Models;

public partial class Rooms
{
    public int Id { get; set; }

    public string RoomName { get; set; } = null!;

    public virtual ICollection<GroupDayTimePlace> GroupDayTimePlace { get; set; } = new List<GroupDayTimePlace>();
}
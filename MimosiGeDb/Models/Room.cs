using System.Collections.Generic;

namespace MimosiGeDb.Models;

public sealed class Room
{
    public int Id { get; set; }

    public string RoomName { get; set; } = null!;

    public ICollection<GroupDayTimePlace> GroupDayTimePlace { get; set; } = new List<GroupDayTimePlace>();
}

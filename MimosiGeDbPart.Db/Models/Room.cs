using System.Collections.Generic;

namespace MimosiGeDbPart.Db.Models;

public sealed class Room
{
    public int Id { get; set; }

    public string RoomName { get; set; } = null!;

    public ICollection<GroupDayTimePlace> GroupDayTimePlace { get; set; } = new List<GroupDayTimePlace>();
}

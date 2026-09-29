using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using BackendCarcass.Domain;

namespace MimosiGeDbPart.Db.Models;

public sealed class Room : IDataType
{
    public int Id { get; set; }

    public string RoomName { get; set; } = null!;

    public ICollection<GroupDayTimePlace> GroupDayTimePlaces { get; set; } = new List<GroupDayTimePlace>();

    [NotMapped] public string? Key => null;

    [NotMapped] public string Name => RoomName;

    [NotMapped] public int? ParentId => null;

    public bool UpdateTo(IDataType data)
    {
        if (data is not Room other)
        {
            return false;
        }

        RoomName = other.RoomName;
        return true;
    }

    public dynamic EditFields()
    {
        return new Room { Id = Id, RoomName = RoomName };
    }
}

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using BackendCarcass.Domain;

namespace MimosiGeDbPart.Db.Models;

public sealed class WeekDay : IDataType
{
    public int Id { get; set; }

    public required string Name { get; set; }

    public required string ShortName { get; set; }

    /// <summary>
    ///     კვირის დღის ნომერი (1 = ორშაბათი)
    /// </summary>
    public int WeekDayNumber { get; set; }

    public ICollection<GroupDayTimePlace> GroupDayTimePlaces { get; set; } = new List<GroupDayTimePlace>();

    [NotMapped] public string? Key => null;

    [NotMapped] public int? ParentId => null;

    public bool UpdateTo(IDataType data)
    {
        if (data is not WeekDay other)
        {
            return false;
        }

        Name = other.Name;
        ShortName = other.ShortName;
        WeekDayNumber = other.WeekDayNumber;
        return true;
    }

    public dynamic EditFields()
    {
        return new WeekDay { Id = Id, Name = Name, ShortName = ShortName, WeekDayNumber = WeekDayNumber };
    }
}

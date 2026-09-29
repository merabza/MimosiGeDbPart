using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using BackendCarcass.Domain;

namespace MimosiGeDbPart.Db.Models;

public sealed class LessonStartTime : IDataType
{
    public int LstId { get; set; }

    /// <summary>
    ///     გაკვეთილის დაწყების დრო
    /// </summary>
    public TimeOnly LstTime { get; set; }

    public ICollection<GroupDayTimePlace> GroupDayTimePlaces { get; set; } = new List<GroupDayTimePlace>();

    [NotMapped]
    public int Id
    {
        get => LstId;
        set => LstId = value;
    }

    [NotMapped] public string? Key => null;

    [NotMapped] public string Name => LstTime.ToString("HH:mm", CultureInfo.InvariantCulture);

    [NotMapped] public int? ParentId => null;

    public bool UpdateTo(IDataType data)
    {
        if (data is not LessonStartTime other)
        {
            return false;
        }

        LstTime = other.LstTime;
        return true;
    }

    public dynamic EditFields()
    {
        return new LessonStartTime { LstId = LstId, LstTime = LstTime };
    }
}

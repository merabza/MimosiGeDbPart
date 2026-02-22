using System;

namespace MimosiGeDbPart.Db.Models;

public sealed class WeekNumber
{
    public int Id { get; set; }

    public int? Number { get; set; }

    public DateTime? FirstDay { get; set; }

    public bool Active { get; set; }
}

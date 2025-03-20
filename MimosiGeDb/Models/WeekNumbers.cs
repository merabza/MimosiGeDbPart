using System;

namespace MimosiGeDb.Models;

public class WeekNumber
{
    public int Id { get; set; }

    public int? Number { get; set; }

    public DateTime? FirstDay { get; set; }

    public bool Active { get; set; }
}
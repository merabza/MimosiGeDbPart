using System;

namespace MimosiGeDb.Models;

public partial class WeekNumbers
{
    public int Id { get; set; }

    public int? WeekNumber { get; set; }

    public DateTime? FirstDay { get; set; }

    public bool Active { get; set; }

}
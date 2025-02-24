using System;

namespace MimosiGeDb.Models;

public partial class AdStuffRealWorkTime
{
    public int Id { get; set; }

    public int AdStuffContractId { get; set; }

    public int AdStuffSubstituteContractId { get; set; }

    public DateTime StartTime { get; set; }

    public DateTime EndTime { get; set; }

    public int? HoursCount { get; set; }
}
using System;

namespace MimosiGeDb.Models;

public partial class AdStuffSubstituteScheme
{
    public int Id { get; set; }

    public int AdStuffContractId { get; set; }

    public int AdSubstituteContractId { get; set; }

    public int WeekDay { get; set; }

    public DateTime StartTime { get; set; }

    public DateTime EndTime { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime? EndDate { get; set; }
}
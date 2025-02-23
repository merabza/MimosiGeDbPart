namespace MimosiGeDb.Models;

public partial class SalaryLinesDetails
{
    public int SadId { get; set; }

    public int SaId { get; set; }

    public decimal SadAmount { get; set; }

    public int GroupId { get; set; }

    public float SadHoursCount { get; set; }

    public decimal SadHourCost { get; set; }
}
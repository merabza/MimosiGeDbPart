using System;

namespace MimosiGeDb.Models;

public partial class GroupsByStudents
{
    public int Id { get; set; }

    public int GroupId { get; set; }

    public int StudentContractId { get; set; }

    public float FourWeekHours { get; set; }

    public decimal FourWeekFee { get; set; }

    public decimal OneHourFee { get; set; }

    public float HoursCoeficient { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime? EndDate { get; set; }

    public string? Note { get; set; }

    public bool DirtyCharges { get; set; }
}
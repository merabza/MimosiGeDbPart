using System;

namespace MimosiGeDb.Models;

public partial class AcademicYears
{
    public int Id { get; set; }

    public string AcademicyearName { get; set; } = null!;

    public DateTime StartDate { get; set; }

    public DateTime? FinishDate { get; set; }
}
using System;

namespace MimosiGeDb.Models;

public class AcademicYear
{
    public int AyId { get; set; }

    public required string AcademicYearName { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime? FinishDate { get; set; }
}
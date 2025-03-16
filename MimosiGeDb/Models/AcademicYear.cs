using System;
using System.Collections.Generic;

namespace MimosiGeDb.Models;

public class AcademicYear
{
    public int AyId { get; set; }

    /// <summary>
    ///     სასწავლო წლის დასახელება
    /// </summary>
    public required string AcademicYearName { get; set; }

    /// <summary>
    ///     სასწავლო წლის დასაწყისი
    /// </summary>
    public DateTime StartDate { get; set; }

    /// <summary>
    ///     სასწავლო წლის დასასრული
    /// </summary>
    public DateTime? FinishDate { get; set; }

    public ICollection<StudentContract> StudentContracts { get; set; } = new List<StudentContract>();
}
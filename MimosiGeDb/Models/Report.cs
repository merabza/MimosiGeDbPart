using System.Collections.Generic;

namespace MimosiGeDb.Models;

public sealed class Report
{
    public int Id { get; set; }

    /// <summary>
    ///     უწყისის სახელი
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    ///     უწყისის სახელი აქსესში
    /// </summary>
    public string? ReportName { get; set; }

    /// <summary>
    ///     ფილტრები
    /// </summary>
    public string? RepFltNames { get; set; }

    public ICollection<ReportByCategory> ReportsByCategories { get; set; } = new List<ReportByCategory>();
}
using System.Collections.Generic;

namespace MimosiGeDb.Models;

public partial class Reports
{
    public int Id { get; set; }

    /// <summary>
    /// უწყისის სახელი
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// უწყისის სახელი აქსესში
    /// </summary>
    public string? ReportName { get; set; }

    /// <summary>
    /// ფილტრები
    /// </summary>
    public string? RepFltNames { get; set; }

    public virtual ICollection<ReportsByCategories> ReportsByCategories { get; set; } = new List<ReportsByCategories>();
}
using System.Collections.Generic;

namespace MimosiGeDb.Models;

public partial class ReportCategory
{
    public int Id { get; set; }

    /// <summary>
    /// უწყისის კატეგორიის სახელი
    /// </summary>
    public string? ReportCategoryName { get; set; }

    public virtual ICollection<ReportByCategory> ReportsByCategories { get; set; } = new List<ReportByCategory>();
}
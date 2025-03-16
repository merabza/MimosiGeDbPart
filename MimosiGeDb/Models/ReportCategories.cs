using System.Collections.Generic;

namespace MimosiGeDb.Models;

public partial class ReportCategories
{
    public int Id { get; set; }

    /// <summary>
    /// უწყისის კატეგორიის სახელი
    /// </summary>
    public string? ReportCategoryName { get; set; }

    public virtual ICollection<ReportsByCategories> ReportsByCategories { get; set; } = new List<ReportsByCategories>();
}
using System.Collections.Generic;

namespace MimosiGeDbPart.Db.Models;

public sealed class ReportCategory
{
    public int Id { get; set; }

    /// <summary>
    ///     უწყისის კატეგორიის სახელი
    /// </summary>
    public required string ReportCategoryName { get; set; }

    public ICollection<ReportByCategory> ReportsByCategories { get; set; } = new List<ReportByCategory>();
}

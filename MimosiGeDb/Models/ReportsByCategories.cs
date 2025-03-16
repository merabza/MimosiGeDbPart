namespace MimosiGeDb.Models;

public partial class ReportsByCategories
{
    public int Id { get; set; }

    /// <summary>
    /// უწყისის კატეგორია
    /// </summary>
    public int? ReportCategoryId { get; set; }

    /// <summary>
    /// უწყისი
    /// </summary>
    public int? ReportId { get; set; }

    public virtual Reports? Report { get; set; }

    public virtual ReportCategories? ReportCategory { get; set; }
}
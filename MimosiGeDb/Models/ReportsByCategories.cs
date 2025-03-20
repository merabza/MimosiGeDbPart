namespace MimosiGeDb.Models;

public partial class ReportByCategory
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

    public virtual Report? Report { get; set; }

    public virtual ReportCategory? ReportCategory { get; set; }
}
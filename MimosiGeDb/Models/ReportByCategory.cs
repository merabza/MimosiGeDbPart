namespace MimosiGeDb.Models;

public sealed class ReportByCategory
{
    public int Id { get; set; }

    /// <summary>
    ///     უწყისის კატეგორია
    /// </summary>
    public int? ReportCategoryId { get; set; }

    /// <summary>
    ///     უწყისი
    /// </summary>
    public int? ReportId { get; set; }

    public Report? Report { get; set; }

    public ReportCategory? ReportCategory { get; set; }
}

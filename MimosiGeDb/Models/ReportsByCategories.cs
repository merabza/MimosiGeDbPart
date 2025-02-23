namespace MimosiGeDb.Models;

public partial class ReportsByCategories
{
    public int Id { get; set; }

    public int? ReportCategoryId { get; set; }

    public int? ReportId { get; set; }
}
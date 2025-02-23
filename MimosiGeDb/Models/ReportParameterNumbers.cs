namespace MimosiGeDb.Models;

public partial class ReportParameterNumbers
{
    public int Id { get; set; }

    public string ParamName { get; set; } = null!;

    public int ParamValue { get; set; }
}
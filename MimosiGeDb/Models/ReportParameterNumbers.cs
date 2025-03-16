namespace MimosiGeDb.Models;

public partial class ReportParameterNumbers
{
    public int Id { get; set; }

    /// <summary>
    /// პარამეტრის სახელი
    /// </summary>
    public string ParamName { get; set; } = null!;

    /// <summary>
    /// პარამეტრის მნიშვნელობა (მთელი რიცხვი)
    /// </summary>
    public int ParamValue { get; set; }
}
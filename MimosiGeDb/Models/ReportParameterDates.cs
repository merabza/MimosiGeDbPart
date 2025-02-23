using System;

namespace MimosiGeDb.Models;

public partial class ReportParameterDates
{
    public int Id { get; set; }

    public string ParamName { get; set; } = null!;

    public DateTime ParamValue { get; set; }
}
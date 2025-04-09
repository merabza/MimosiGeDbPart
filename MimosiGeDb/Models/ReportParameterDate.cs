using System;

namespace MimosiGeDb.Models;

public sealed class ReportParameterDate
{
    public int Id { get; set; }

    /// <summary>
    ///     პარამეტრის სახელი
    /// </summary>
    public string ParamName { get; set; } = null!;

    /// <summary>
    ///     პარამეტრის მნიშვნელობა (თარიღი და დრო)
    /// </summary>
    public DateTime ParamValue { get; set; }
}
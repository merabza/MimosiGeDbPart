using System;

namespace MimosiGeDbPart.Db.Models;

public sealed class OperationMonth
{
    public int Id { get; set; }

    /// <summary>
    ///     თვე (თვის პირველი დღე)
    /// </summary>
    public DateTime MonthDate { get; set; }
}

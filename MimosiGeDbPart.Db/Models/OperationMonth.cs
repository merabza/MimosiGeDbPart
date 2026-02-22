using System;
using System.Collections.Generic;

namespace MimosiGeDbPart.Db.Models;

public sealed class OperationMonth
{
    public int Id { get; set; }

    /// <summary>
    ///     თვე
    /// </summary>
    public DateTime? MonthDate { get; set; }

    public ICollection<SalaryCharge> SalaryCharges { get; set; } = new List<SalaryCharge>();

    public ICollection<SummaryComment> SummaryComments { get; set; } = new List<SummaryComment>();
}

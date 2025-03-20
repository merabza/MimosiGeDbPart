using System;
using System.Collections.Generic;

namespace MimosiGeDb.Models;

public partial class OperationMonth
{
    public int Id { get; set; }

    /// <summary>
    /// თვე
    /// </summary>
    public DateTime? MonthDate { get; set; }

    public virtual ICollection<SalaryCharge> SalaryCharges { get; set; } = new List<SalaryCharge>();

    public virtual ICollection<SummaryComment> SummaryComments { get; set; } = new List<SummaryComment>();
}
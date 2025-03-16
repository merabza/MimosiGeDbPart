using System;
using System.Collections.Generic;

namespace MimosiGeDb.Models;

public partial class OperationMonths
{
    public int Id { get; set; }

    /// <summary>
    /// თვე
    /// </summary>
    public DateTime? MonthDate { get; set; }

    public virtual ICollection<SalaryCharges> SalaryCharges { get; set; } = new List<SalaryCharges>();

    public virtual ICollection<SummaryComments> SummaryComments { get; set; } = new List<SummaryComments>();
}
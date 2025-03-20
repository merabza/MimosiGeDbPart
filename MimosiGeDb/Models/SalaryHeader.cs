using System;
using System.Collections.Generic;

namespace MimosiGeDb.Models;

public partial class SalaryHeader
{
    public int ShId { get; set; }

    /// <summary>
    /// დარიცხვის თარიღი
    /// </summary>
    public DateTime ShChargeDate { get; set; }

    /// <summary>
    /// გადარიცხვის თარიღი
    /// </summary>
    public DateTime ShTransferDate { get; set; }

    public virtual ICollection<SalaryLine> SalaryLines { get; set; } = new List<SalaryLine>();

    public virtual ICollection<SalaryPart> SalaryParts { get; set; } = new List<SalaryPart>();
}
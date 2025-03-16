using System;
using System.Collections.Generic;

namespace MimosiGeDb.Models;

public partial class SalaryHeaders
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

    public virtual ICollection<SalaryLines> SalaryLines { get; set; } = new List<SalaryLines>();

    public virtual ICollection<SalaryParts> SalaryParts { get; set; } = new List<SalaryParts>();
}
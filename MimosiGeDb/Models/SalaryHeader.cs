using System;
using System.Collections.Generic;

namespace MimosiGeDb.Models;

public sealed class SalaryHeader
{
    public int ShId { get; set; }

    /// <summary>
    ///     დარიცხვის თარიღი
    /// </summary>
    public DateTime ShChargeDate { get; set; }

    /// <summary>
    ///     გადარიცხვის თარიღი
    /// </summary>
    public DateTime ShTransferDate { get; set; }

    public ICollection<SalaryLine> SalaryLines { get; set; } = new List<SalaryLine>();

    public ICollection<SalaryPart> SalaryParts { get; set; } = new List<SalaryPart>();
}
using System.Collections.Generic;

namespace MimosiGeDb.Models;

public sealed class RsQuoteType
{
    public int QtId { get; set; }

    public required string QtName { get; set; }

    public ICollection<RsTaxRate> RsTaxRates { get; set; } = new List<RsTaxRate>();

    public ICollection<SalaryLine> SalaryLines { get; set; } = new List<SalaryLine>();

    public ICollection<TeacherContract> TeacherContracts { get; set; } = new List<TeacherContract>();
}
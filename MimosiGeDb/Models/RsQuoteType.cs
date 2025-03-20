using System.Collections.Generic;

namespace MimosiGeDb.Models;

public partial class RsQuoteType
{
    public short QtId { get; set; }

    public string? QtName { get; set; }

    public virtual ICollection<RsTaxRate> RsTaxRates { get; set; } = new List<RsTaxRate>();

    public virtual ICollection<SalaryLine> SalaryLines { get; set; } = new List<SalaryLine>();

    public virtual ICollection<TeacherContract> TeacherContracts { get; set; } = new List<TeacherContract>();
}
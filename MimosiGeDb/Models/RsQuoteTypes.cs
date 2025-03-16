using System.Collections.Generic;

namespace MimosiGeDb.Models;

public partial class RsQuoteTypes
{
    public short QtId { get; set; }

    public string? QtName { get; set; }

    public virtual ICollection<RsTaxRates> RsTaxRates { get; set; } = new List<RsTaxRates>();

    public virtual ICollection<SalaryLines> SalaryLines { get; set; } = new List<SalaryLines>();

    public virtual ICollection<TeacherContracts> TeacherContracts { get; set; } = new List<TeacherContracts>();
}
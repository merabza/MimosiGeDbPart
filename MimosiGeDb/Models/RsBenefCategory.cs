using System.Collections.Generic;

namespace MimosiGeDb.Models;

public class RsBenefCategory
{
    public short QtId { get; set; }

    public string? QtName { get; set; }

    public virtual ICollection<RsTaxRate> RsTaxRates { get; set; } = new List<RsTaxRate>();
}
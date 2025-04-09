using System.Collections.Generic;

namespace MimosiGeDb.Models;

public sealed class RsBenefCategory
{
    public short QtId { get; set; }

    public string? QtName { get; set; }

    public ICollection<RsTaxRate> RsTaxRates { get; set; } = new List<RsTaxRate>();
}
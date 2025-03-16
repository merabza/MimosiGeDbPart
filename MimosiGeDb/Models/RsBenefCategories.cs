using System.Collections.Generic;

namespace MimosiGeDb.Models;

public partial class RsBenefCategories
{
    public short QtId { get; set; }

    public string? QtName { get; set; }

    public virtual ICollection<RsTaxRates> RsTaxRates { get; set; } = new List<RsTaxRates>();
}
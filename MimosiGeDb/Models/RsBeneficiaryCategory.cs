using System.Collections.Generic;

namespace MimosiGeDb.Models;

public sealed class RsBeneficiaryCategory
{
    public short RbfId { get; set; }

    public string? RbfName { get; set; }

    public ICollection<RsTaxRate> RsTaxRates { get; set; } = new List<RsTaxRate>();
}
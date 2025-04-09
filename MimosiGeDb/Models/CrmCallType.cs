using System.Collections.Generic;

namespace MimosiGeDb.Models;

public sealed class CrmCallType
{
    public int CctId { get; set; }

    public required string CallTypeName { get; set; }

    public ICollection<CrmCall> CrmCalls { get; set; } = new List<CrmCall>();
}
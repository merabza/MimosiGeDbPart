using System.Collections.Generic;

namespace MimosiGeDbPart.Db.Models;

public sealed class CrmCallType
{
    public int CctId { get; set; }

    public required string CallTypeName { get; set; }

    public ICollection<CrmCall> CrmCalls { get; set; } = new List<CrmCall>();
}

using System.Collections.Generic;

namespace MimosiGeDbPart.Db.Models;

public sealed class CrmAnswerType
{
    public int CatId { get; set; }
    public string? CatKey { get; set; }

    /// <summary>
    ///     პასუხის ტიპის სახელი
    /// </summary>
    public required string AnswerTypeName { get; set; }

    public ICollection<CrmCall> CrmCalls { get; set; } = new List<CrmCall>();
}

using System.Collections.Generic;

namespace MimosiGeDb.Models;

public class CrmAnswerType
{
    public int CatId { get; set; }

    /// <summary>
    ///     პასუხის ტიპის სახელი
    /// </summary>
    public required string AnswerName { get; set; }

    public ICollection<CrmCall> CrmCalls { get; set; } = new List<CrmCall>();
}
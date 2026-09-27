using System.Collections.Generic;

namespace MimosiGeDbPart.Db.Models;

public sealed class SalaryPartType
{
    public int SptId { get; set; }

    /// <summary>
    ///     სახელი
    /// </summary>
    public required string SptName { get; set; }

    /// <summary>
    ///     გამოთვლებში მონაწილეობის ადგილი: 1 = დანამატი, 2 = გამოქვითვა ხელზე ასაღებიდან
    /// </summary>
    public int? SptCountPlaceId { get; set; }

    /// <summary>
    ///     განაცემის ტიპის იდენტიფიკატორი
    /// </summary>
    public int? RsQuoteTypeId { get; set; }

    public RsQuoteType? RsQuoteType { get; set; }

    public ICollection<SalaryPart> SalaryParts { get; set; } = new List<SalaryPart>();
}

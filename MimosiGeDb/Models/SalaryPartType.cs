﻿using System.Collections.Generic;

namespace MimosiGeDb.Models;

public class SalaryPartType
{
    public int SptId { get; set; }

    /// <summary>
    ///     სახელი
    /// </summary>
    public string? SptName { get; set; }

    /// <summary>
    ///     გამოთვლებში მონაწილეობის ადგილი
    /// </summary>
    public int? SptCountPlaceId { get; set; }

    /// <summary>
    ///     განაცემის ტიპის იდენტიფიკატორი
    /// </summary>
    public int? RsQuoteTypeId { get; set; }

    public virtual ICollection<SalaryPart> SalaryParts { get; set; } = new List<SalaryPart>();
}
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using BackendCarcass.Domain;

namespace MimosiGeDbPart.Db.Models;

public sealed class SalaryPartType : IDataType
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

    [NotMapped]
    public int Id
    {
        get => SptId;
        set => SptId = value;
    }

    [NotMapped] public string? Key => null;

    [NotMapped] public string Name => SptName;

    [NotMapped] public int? ParentId => null;

    public bool UpdateTo(IDataType data)
    {
        if (data is not SalaryPartType other)
        {
            return false;
        }

        SptName = other.SptName;
        SptCountPlaceId = other.SptCountPlaceId;
        RsQuoteTypeId = other.RsQuoteTypeId;
        return true;
    }

    public dynamic EditFields()
    {
        return new SalaryPartType
        {
            SptId = SptId, SptName = SptName, SptCountPlaceId = SptCountPlaceId, RsQuoteTypeId = RsQuoteTypeId
        };
    }
}

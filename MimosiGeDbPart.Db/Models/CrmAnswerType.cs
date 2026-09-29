using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using BackendCarcass.Domain;

namespace MimosiGeDbPart.Db.Models;

public sealed class CrmAnswerType : IDataType
{
    public int CatId { get; set; }
    public string? CatKey { get; set; }

    /// <summary>
    ///     პასუხის ტიპის სახელი
    /// </summary>
    public required string AnswerTypeName { get; set; }

    public ICollection<CrmCall> CrmCalls { get; set; } = new List<CrmCall>();

    [NotMapped]
    public int Id
    {
        get => CatId;
        set => CatId = value;
    }

    [NotMapped] public string? Key => CatKey;

    [NotMapped] public string Name => AnswerTypeName;

    [NotMapped] public int? ParentId => null;

    public bool UpdateTo(IDataType data)
    {
        if (data is not CrmAnswerType other)
        {
            return false;
        }

        CatKey = other.CatKey;
        AnswerTypeName = other.AnswerTypeName;
        return true;
    }

    public dynamic EditFields()
    {
        return new CrmAnswerType { CatId = CatId, CatKey = CatKey, AnswerTypeName = AnswerTypeName };
    }
}

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using BackendCarcass.Domain;

namespace MimosiGeDbPart.Db.Models;

public sealed class CrmCallType : IDataType
{
    public int CctId { get; set; }

    public required string CallTypeName { get; set; }

    public ICollection<CrmCall> CrmCalls { get; set; } = new List<CrmCall>();

    [NotMapped]
    public int Id
    {
        get => CctId;
        set => CctId = value;
    }

    [NotMapped] public string? Key => null;

    [NotMapped] public string Name => CallTypeName;

    [NotMapped] public int? ParentId => null;

    public bool UpdateTo(IDataType data)
    {
        if (data is not CrmCallType other)
        {
            return false;
        }

        CallTypeName = other.CallTypeName;
        return true;
    }

    public dynamic EditFields()
    {
        return new CrmCallType { CctId = CctId, CallTypeName = CallTypeName };
    }
}

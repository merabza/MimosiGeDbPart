using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using BackendCarcass.Domain;

namespace MimosiGeDbPart.Db.Models;

public sealed class GroupSize : IDataType
{
    public int GrsId { get; set; }

    /// <summary>
    ///     ადგილების რაოდენობა ჯგუფში
    /// </summary>
    public int GrsSize { get; set; }

    /// <summary>
    ///     ჯგუფის ზომის დასახელება
    /// </summary>
    public required string GrsName { get; set; }

    public ICollection<Group> Groups { get; set; } = new List<Group>();
    public ICollection<StudentContractDetail> StudentContractDetails { get; set; } = new List<StudentContractDetail>();

    [NotMapped]
    public int Id
    {
        get => GrsId;
        set => GrsId = value;
    }

    [NotMapped] public string? Key => null;

    [NotMapped] public string Name => GrsName;

    [NotMapped] public int? ParentId => null;

    public bool UpdateTo(IDataType data)
    {
        if (data is not GroupSize other)
        {
            return false;
        }

        GrsSize = other.GrsSize;
        GrsName = other.GrsName;
        return true;
    }

    public dynamic EditFields()
    {
        return new GroupSize { GrsId = GrsId, GrsSize = GrsSize, GrsName = GrsName };
    }
}

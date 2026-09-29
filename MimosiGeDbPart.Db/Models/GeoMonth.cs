using System.ComponentModel.DataAnnotations.Schema;
using BackendCarcass.Domain;

namespace MimosiGeDbPart.Db.Models;

public sealed class GeoMonth : IDataType
{
    public int GmnId { get; set; }

    /// <summary>
    ///     თვის სახელი
    /// </summary>
    public required string GmnName { get; set; }

    /// <summary>
    ///     მიცემით ბრუნვაში
    /// </summary>
    public required string GmnDative { get; set; }

    [NotMapped]
    public int Id
    {
        get => GmnId;
        set => GmnId = value;
    }

    [NotMapped] public string? Key => null;

    [NotMapped] public string Name => GmnName;

    [NotMapped] public int? ParentId => null;

    public bool UpdateTo(IDataType data)
    {
        if (data is not GeoMonth other)
        {
            return false;
        }

        GmnName = other.GmnName;
        GmnDative = other.GmnDative;
        return true;
    }

    public dynamic EditFields()
    {
        return new GeoMonth { GmnId = GmnId, GmnName = GmnName, GmnDative = GmnDative };
    }
}

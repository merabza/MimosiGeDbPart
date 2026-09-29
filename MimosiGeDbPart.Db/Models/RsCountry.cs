using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using BackendCarcass.Domain;

namespace MimosiGeDbPart.Db.Models;

public sealed class RsCountry : IDataType
{
    public int Id { get; set; }

    /// <summary>
    ///     ქვეყნის კოდი (შემოსავლების სამსახურის)
    /// </summary>
    public required string Code { get; set; }

    /// <summary>
    ///     ქვეყნის დასახელება
    /// </summary>
    public required string CountryName { get; set; }

    public ICollection<TeacherContract> TeacherContracts { get; set; } = new List<TeacherContract>();

    [NotMapped] public string Key => Code;

    [NotMapped] public string Name => CountryName;

    [NotMapped] public int? ParentId => null;

    public bool UpdateTo(IDataType data)
    {
        if (data is not RsCountry other)
        {
            return false;
        }

        Code = other.Code;
        CountryName = other.CountryName;
        return true;
    }

    public dynamic EditFields()
    {
        return new RsCountry { Id = Id, Code = Code, CountryName = CountryName };
    }
}

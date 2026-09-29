using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using BackendCarcass.Domain;

namespace MimosiGeDbPart.Db.Models;

public sealed class WorkHourGroup : IDataType
{
    /// <summary>
    ///     იდენტიფიკატორი
    /// </summary>
    public int WhgId { get; set; }

    /// <summary>
    ///     გასაღები
    /// </summary>
    public required string WhgKey { get; set; }

    /// <summary>
    ///     სახელი
    /// </summary>
    public required string WhgName { get; set; }

    /// <summary>
    ///     ჯგუფის ხელფასი
    /// </summary>
    public decimal WhgSalaryNet { get; set; }

    public ICollection<TeacherContract> TeacherContracts { get; set; } = new List<TeacherContract>();

    [NotMapped]
    public int Id
    {
        get => WhgId;
        set => WhgId = value;
    }

    [NotMapped] public string Key => WhgKey;

    [NotMapped] public string Name => WhgName;

    [NotMapped] public int? ParentId => null;

    public bool UpdateTo(IDataType data)
    {
        if (data is not WorkHourGroup other)
        {
            return false;
        }

        WhgKey = other.WhgKey;
        WhgName = other.WhgName;
        WhgSalaryNet = other.WhgSalaryNet;
        return true;
    }

    public dynamic EditFields()
    {
        return new WorkHourGroup { WhgId = WhgId, WhgKey = WhgKey, WhgName = WhgName, WhgSalaryNet = WhgSalaryNet };
    }
}

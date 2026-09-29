using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using BackendCarcass.Domain;

namespace MimosiGeDbPart.Db.Models;

public sealed class RsQuoteType : IDataType
{
    public int QtId { get; set; }

    public required string QtName { get; set; }

    public ICollection<SalaryLine> SalaryLines { get; set; } = new List<SalaryLine>();

    public ICollection<SalaryPartType> SalaryPartTypes { get; set; } = new List<SalaryPartType>();

    public ICollection<TeacherContract> TeacherContracts { get; set; } = new List<TeacherContract>();

    [NotMapped]
    public int Id
    {
        get => QtId;
        set => QtId = value;
    }

    [NotMapped] public string? Key => null;

    [NotMapped] public string Name => QtName;

    [NotMapped] public int? ParentId => null;

    public bool UpdateTo(IDataType data)
    {
        if (data is not RsQuoteType other)
        {
            return false;
        }

        QtName = other.QtName;
        return true;
    }

    public dynamic EditFields()
    {
        return new RsQuoteType { QtId = QtId, QtName = QtName };
    }
}

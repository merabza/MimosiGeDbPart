using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using BackendCarcass.MasterData;

namespace MimosiGeDbPart.Db.Models;

public sealed class Course : IDataType
{
    public int CrsId { get; set; }

    /// <summary>
    ///     კურსის, საგნის სახელი
    /// </summary>
    public required string CourseName { get; set; }

    public ICollection<Group> Groups { get; set; } = new List<Group>();

    public ICollection<StudentContractDetail> StudentContractDetails { get; set; } = new List<StudentContractDetail>();

    public ICollection<SummaryComment> SummaryComments { get; set; } = new List<SummaryComment>();

    //[NotMapped] public static string DtKeyKey => nameof(CrsId).CountDtKey();

    [NotMapped]
    public int Id
    {
        get => CrsId;
        set => CrsId = value;
    }

    [NotMapped] public string? Key => null;

    [NotMapped] public string Name => CourseName;

    [NotMapped] public int? ParentId => null;

    public bool UpdateTo(IDataType data)
    {
        if (data is not Course other)
        {
            return false;
        }

        return CrsId == other.CrsId && CourseName == other.CourseName;
    }

    public dynamic EditFields()
    {
        return new Course { CrsId = CrsId, CourseName = CourseName };
    }
}

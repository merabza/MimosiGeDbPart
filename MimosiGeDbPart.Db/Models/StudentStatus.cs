using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using BackendCarcass.Domain;

namespace MimosiGeDbPart.Db.Models;

public sealed class StudentStatus : IDataType
{
    public int Id { get; set; }

    /// <summary>
    ///     მოსწავლის სტატუსის სახელი
    /// </summary>
    public string StudentStatusName { get; set; }

    /// <summary>
    ///     დალაგების რიგი
    /// </summary>
    public int Rate { get; set; }

    public ICollection<Group> Groups { get; set; } = new List<Group>();

    public ICollection<StudentContract> StudentContracts { get; set; } = new List<StudentContract>();

    [NotMapped] public string? Key => null;

    [NotMapped] public string Name => StudentStatusName;

    [NotMapped] public int? ParentId => null;

    public bool UpdateTo(IDataType data)
    {
        if (data is not StudentStatus other)
        {
            return false;
        }

        StudentStatusName = other.StudentStatusName;
        Rate = other.Rate;
        return true;
    }

    public dynamic EditFields()
    {
        return new StudentStatus { Id = Id, StudentStatusName = StudentStatusName, Rate = Rate };
    }
}

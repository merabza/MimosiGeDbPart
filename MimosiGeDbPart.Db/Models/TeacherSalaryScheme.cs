using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using BackendCarcass.Domain;

namespace MimosiGeDbPart.Db.Models;

public sealed class TeacherSalaryScheme : IDataType
{
    public int Id { get; set; }

    /// <summary>
    ///     სქემის სახელი
    /// </summary>
    public required string SchemaName { get; set; }

    /// <summary>
    ///     საათობრივი ხელფასი ხელზე
    /// </summary>
    public decimal HourSalaryNet { get; set; }

    /// <summary>
    ///     საათობრივი ხელფასი დარიცხული
    /// </summary>
    public decimal HourSalaryGross { get; set; }

    public ICollection<GroupByTeacher> GroupsByTeachers { get; set; } = new List<GroupByTeacher>();

    public ICollection<Lesson> Lessons { get; set; } = new List<Lesson>();

    public ICollection<TeacherContract> TeacherContracts { get; set; } = new List<TeacherContract>();

    [NotMapped] public string? Key => null;

    [NotMapped] public string Name => SchemaName;

    [NotMapped] public int? ParentId => null;

    public bool UpdateTo(IDataType data)
    {
        if (data is not TeacherSalaryScheme other)
        {
            return false;
        }

        SchemaName = other.SchemaName;
        HourSalaryNet = other.HourSalaryNet;
        HourSalaryGross = other.HourSalaryGross;
        return true;
    }

    public dynamic EditFields()
    {
        return new TeacherSalaryScheme
        {
            Id = Id, SchemaName = SchemaName, HourSalaryNet = HourSalaryNet, HourSalaryGross = HourSalaryGross
        };
    }
}

using System.Collections.Generic;

namespace MimosiGeDbPart.Db.Models;

public sealed class TeacherSalaryScheme
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
}

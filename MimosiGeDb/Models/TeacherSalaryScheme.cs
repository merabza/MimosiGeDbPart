using System.Collections.Generic;

namespace MimosiGeDb.Models;

public class TeacherSalaryScheme
{
    public int Id { get; set; }

    /// <summary>
    ///     სქემის სახელი
    /// </summary>
    public string? SchemaName { get; set; }

    /// <summary>
    ///     საათობრივი ხელფასი ხელზე
    /// </summary>
    public double? HourSalaryNet { get; set; }

    /// <summary>
    ///     საათობრივი ხელფასი დარიცხული
    /// </summary>
    public double? HourSalaryGross { get; set; }

    public virtual ICollection<TeacherContract> TeacherContracts { get; set; } = new List<TeacherContract>();
}
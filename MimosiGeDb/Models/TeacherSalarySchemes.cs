using System.Collections.Generic;

namespace MimosiGeDb.Models;

public partial class TeacherSalarySchemes
{
    public int Id { get; set; }

    /// <summary>
    /// სქემის სახელი
    /// </summary>
    public string? SchemaName { get; set; }

    /// <summary>
    /// საათობრივი ხელფასი ხელზე
    /// </summary>
    public double? HourSalaryNet { get; set; }

    /// <summary>
    /// საათობრივი ხელფასი დარიცხული
    /// </summary>
    public double? HourSalaryGross { get; set; }

    public virtual ICollection<TeacherContracts> TeacherContracts { get; set; } = new List<TeacherContracts>();
}
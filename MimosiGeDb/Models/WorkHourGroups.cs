using System.Collections.Generic;

namespace MimosiGeDb.Models;

public sealed class WorkHourGroups
{
    /// <summary>
    ///     იდენტიფიკატორი
    /// </summary>
    public int WhgId { get; set; }

    /// <summary>
    ///     გასაღები
    /// </summary>
    public string? WhgKey { get; set; }

    /// <summary>
    ///     სახელი
    /// </summary>
    public string? WhgName { get; set; }

    /// <summary>
    ///     ჯგუფის ხელფასი
    /// </summary>
    public decimal? WhgSalaryNet { get; set; }

    public ICollection<TeacherContract> TeacherContracts { get; set; } = new List<TeacherContract>();
}
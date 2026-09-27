using System.Collections.Generic;

namespace MimosiGeDbPart.Db.Models;

public sealed class WorkHourGroup
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
}

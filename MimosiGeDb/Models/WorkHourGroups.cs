using System.Collections.Generic;

namespace MimosiGeDb.Models;

public partial class WorkHourGroups
{
    /// <summary>
    /// იდენტიფიკატორი
    /// </summary>
    public int WhgId { get; set; }

    /// <summary>
    /// გასაღები
    /// </summary>
    public string? WhgKey { get; set; }

    /// <summary>
    /// სახელი
    /// </summary>
    public string? WhgName { get; set; }

    /// <summary>
    /// ჯგუფის ხელფასი
    /// </summary>
    public decimal? WhgSalaryNet { get; set; }

    public virtual ICollection<TeacherContracts> TeacherContracts { get; set; } = new List<TeacherContracts>();
}
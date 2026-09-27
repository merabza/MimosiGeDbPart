using System.Collections.Generic;

namespace MimosiGeDbPart.Db.Models;

public sealed class RsQuoteType
{
    public int QtId { get; set; }

    public required string QtName { get; set; }

    public ICollection<SalaryLine> SalaryLines { get; set; } = new List<SalaryLine>();

    public ICollection<SalaryPartType> SalaryPartTypes { get; set; } = new List<SalaryPartType>();

    public ICollection<TeacherContract> TeacherContracts { get; set; } = new List<TeacherContract>();
}

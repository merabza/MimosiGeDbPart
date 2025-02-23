using System;

namespace MimosiGeDb.Models;

public partial class WorkHours
{
    public int WhId { get; set; }

    public int TeacherContractId { get; set; }

    public DateTime WhStart { get; set; }

    public DateTime? WhEnd { get; set; }
}
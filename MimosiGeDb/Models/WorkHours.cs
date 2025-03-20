﻿using System;

namespace MimosiGeDb.Models;

public partial class WorkHours
{
    public int WhId { get; set; }

    /// <summary>
    /// თანამშრომელი
    /// </summary>
    public int TeacherContractId { get; set; }

    /// <summary>
    /// მუშაობის დაწყების თარიღი და დრო
    /// </summary>
    public DateTime WhStart { get; set; }

    /// <summary>
    /// მუშაობის დასრულების თარიღი და დრო
    /// </summary>
    public DateTime? WhEnd { get; set; }

    public virtual TeacherContract TeacherContract { get; set; } = null!;
}
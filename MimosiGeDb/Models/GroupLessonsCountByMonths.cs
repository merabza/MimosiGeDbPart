using System;

namespace MimosiGeDb.Models;

public partial class GroupLessonsCountByMonths
{
    public int Id { get; set; }

    public int? GroupId { get; set; }

    public DateTime? MonthDate { get; set; }

    public int? LessonsCount { get; set; }
}
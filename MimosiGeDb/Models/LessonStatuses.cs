using System.Collections.Generic;

namespace MimosiGeDb.Models;

public partial class LessonStatuses
{
    public int Id { get; set; }

    public string? StatusName { get; set; }

    public virtual ICollection<Lessons> Lessons { get; set; } = new List<Lessons>();
}
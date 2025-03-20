using System.Collections.Generic;

namespace MimosiGeDb.Models;

public partial class LessonStatus
{
    public int Id { get; set; }

    public string? StatusName { get; set; }

    public virtual ICollection<Lesson> Lessons { get; set; } = new List<Lesson>();
}
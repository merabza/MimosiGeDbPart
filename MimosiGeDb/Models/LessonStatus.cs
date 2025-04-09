using System.Collections.Generic;

namespace MimosiGeDb.Models;

public sealed class LessonStatus
{
    public int Id { get; set; }

    public string? StatusName { get; set; }

    public ICollection<Lesson> Lessons { get; set; } = new List<Lesson>();
}
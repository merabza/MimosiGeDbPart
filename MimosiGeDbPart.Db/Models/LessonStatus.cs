using System.Collections.Generic;

namespace MimosiGeDbPart.Db.Models;

public sealed class LessonStatus
{
    public int Id { get; set; }

    /// <summary>
    ///     სტატუსის დასახელება
    /// </summary>
    public required string StatusName { get; set; }

    public ICollection<Lesson> Lessons { get; set; } = new List<Lesson>();
}

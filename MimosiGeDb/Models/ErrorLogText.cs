using System.Collections.Generic;

namespace MimosiGeDb.Models;

public sealed class ErrorLogText
{
    public int EltId { get; set; }

    /// <summary>
    ///     შეცდომის ტექსტი
    /// </summary>
    public required string Text { get; set; }

    public ICollection<LessonCheckCreateErrorLog> LessonsCheckCreateErrorLogs { get; set; } =
        new List<LessonCheckCreateErrorLog>();
}
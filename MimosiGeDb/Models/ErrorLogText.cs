using System.Collections.Generic;

namespace MimosiGeDb.Models;

public class ErrorLogText
{
    public int EltId { get; set; }

    /// <summary>
    ///     შეცდომის ტექსტი
    /// </summary>
    public required string Text { get; set; }

    public ICollection<LessonsCheckCreateErrorLogs> LessonsCheckCreateErrorLogs { get; set; } =
        new List<LessonsCheckCreateErrorLogs>();
}
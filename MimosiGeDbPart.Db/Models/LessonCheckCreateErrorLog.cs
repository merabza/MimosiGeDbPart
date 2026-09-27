using System;

namespace MimosiGeDbPart.Db.Models;

public sealed class LessonCheckCreateErrorLog
{
    public int Id { get; set; }

    /// <summary>
    ///     ლოგის შექმნის თარიღი და დრო
    /// </summary>
    public DateTime CreatedDate { get; set; }

    /// <summary>
    ///     ჯგუფი
    /// </summary>
    public int GroupId { get; set; }

    /// <summary>
    ///     გაკვეთილის თარიღი
    /// </summary>
    public DateTime? LessonDate { get; set; }

    /// <summary>
    ///     გაკვეთილი
    /// </summary>
    public int? LessonId { get; set; }

    /// <summary>
    ///     შეცდომის კოდი
    /// </summary>
    public int ErrorLogTextId { get; set; }

    public ErrorLogText ErrorLogText { get; set; } = null!;

    public Group Group { get; set; } = null!;

    public Lesson? Lesson { get; set; }
}

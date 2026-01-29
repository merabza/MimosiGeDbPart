using System;

namespace MimosiGeDb.Models;

public sealed class LessonCheckCreateErrorLog
{
    private ErrorLogText? _errorLogTextNavigation;

    private Group? _groupNavigation;
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
    public int ErrorId { get; set; }

    /// <summary>
    ///     დასაშვებია ავტომატური გასწორება
    /// </summary>
    public bool AllowUpdate { get; set; }

    public ErrorLogText ErrorLogTextNavigation
    {
        get =>
            _errorLogTextNavigation ??
            throw new InvalidOperationException("Uninitialized property: " + nameof(_errorLogTextNavigation));
        set => _errorLogTextNavigation = value;
    }

    public Group GroupNavigation
    {
        get =>
            _groupNavigation ??
            throw new InvalidOperationException("Uninitialized property: " + nameof(GroupNavigation));
        set => _groupNavigation = value;
    }

    public Lesson? Lesson { get; set; }
}

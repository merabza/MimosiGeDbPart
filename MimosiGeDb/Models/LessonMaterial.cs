using System;

namespace MimosiGeDb.Models;

public class LessonMaterial
{
    private Lessons? _lessonsNavigation;

    private Material? _materialNavigation;


    public int LmId { get; set; }

    /// <summary>
    ///     გაკვეთილი
    /// </summary>
    public int LessonId { get; set; }

    /// <summary>
    ///     მასალის იდენტიფიკატორი
    /// </summary>
    public int MatId { get; set; }

    public Material MaterialNavigation
    {
        get =>
            _materialNavigation ??
            throw new InvalidOperationException("Uninitialized property: " + nameof(MaterialNavigation));
        set => _materialNavigation = value;
    }

    public Lessons LessonsNavigation
    {
        get =>
            _lessonsNavigation ??
            throw new InvalidOperationException("Uninitialized property: " + nameof(LessonsNavigation));
        set => _lessonsNavigation = value;
    }
}
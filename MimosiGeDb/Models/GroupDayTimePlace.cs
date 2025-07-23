using System;

namespace MimosiGeDb.Models;

public sealed class GroupDayTimePlace
{
    private Group? _groupNavigation;

    private LessonStartTime? _lessonStartTime;
    private Room? _roomNavigation;

    private WeekDay? _weekDayNavigation;
    public int GdtpId { get; set; }

    /// <summary>
    ///     ჯგუფი
    /// </summary>
    public int GroupId { get; set; }

    /// <summary>
    ///     კვირის დღე
    /// </summary>
    public int WeekDay { get; set; }

    /// <summary>
    ///     დრო
    /// </summary>
    public int LessonStarTimeId { get; set; }

    /// <summary>
    ///     საათები
    /// </summary>
    public float HoursCount { get; set; }

    /// <summary>
    ///     ოთახი
    /// </summary>
    public int RoomId { get; set; }

    /// <summary>
    ///     გააქტიურების თარიღი
    /// </summary>
    public DateTime StartDate { get; set; }

    /// <summary>
    ///     გაუქმების თარიღი
    /// </summary>
    public DateTime? EndDate { get; set; }

    public Group GroupNavigation
    {
        get =>
            _groupNavigation ??
            throw new InvalidOperationException("Uninitialized property: " + nameof(GroupNavigation));
        set => _groupNavigation = value;
    }

    public Room RoomNavigation
    {
        get =>
            _roomNavigation ?? throw new InvalidOperationException("Uninitialized property: " + nameof(RoomNavigation));
        set => _roomNavigation = value;
    }

    public LessonStartTime LessonStartTimeNavigation
    {
        get =>
            _lessonStartTime ??
            throw new InvalidOperationException("Uninitialized property: " + nameof(LessonStartTimeNavigation));
        set => _lessonStartTime = value;
    }

    public WeekDay WeekDayNavigation
    {
        get =>
            _weekDayNavigation ??
            throw new InvalidOperationException("Uninitialized property: " + nameof(WeekDayNavigation));
        set => _weekDayNavigation = value;
    }
}
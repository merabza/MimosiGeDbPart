using System;

namespace MimosiGeDbPart.Db.Models;

public sealed class GroupDayTimePlace
{
    public int GdtpId { get; set; }

    /// <summary>
    ///     ჯგუფი
    /// </summary>
    public int GroupId { get; set; }

    /// <summary>
    ///     კვირის დღე
    /// </summary>
    public int WeekDayId { get; set; }

    /// <summary>
    ///     გაკვეთილის დაწყების დრო
    /// </summary>
    public int LessonStartTimeId { get; set; }

    /// <summary>
    ///     საათები
    /// </summary>
    public float HoursCount { get; set; } = 1f;

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

    public Group Group { get; set; } = null!;

    public LessonStartTime LessonStartTime { get; set; } = null!;

    public Room Room { get; set; } = null!;

    public WeekDay WeekDay { get; set; } = null!;
}

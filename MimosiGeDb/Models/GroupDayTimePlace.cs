using System;

namespace MimosiGeDb.Models;

public partial class GroupDayTimePlace
{
    public int Id { get; set; }

    public int GroupId { get; set; }

    public int WeekDay { get; set; }

    public DateTime Time { get; set; }

    public float HoursCount { get; set; }

    public int RoomId { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime? EndDate { get; set; }
}
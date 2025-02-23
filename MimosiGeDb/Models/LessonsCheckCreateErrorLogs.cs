using System;

namespace MimosiGeDb.Models;

public partial class LessonsCheckCreateErrorLogs
{
    public int Id { get; set; }

    public DateTime CreatedDate { get; set; }

    public int GroupId { get; set; }

    public DateTime? LessonDate { get; set; }

    public int? LessonId { get; set; }

    public int ErrorId { get; set; }

    public bool AllowUpdate { get; set; }
}
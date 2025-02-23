namespace MimosiGeDb.Models;

public partial class LessonsByStudents
{
    public int Id { get; set; }

    public int LessonId { get; set; }

    public int StudentContractId { get; set; }

    public int? GroupByStudentId { get; set; }

    public float HoursCount { get; set; }

    public bool Present { get; set; }

    public string? Theme { get; set; }

    public float? Rate { get; set; }

    public string? TeacherComment { get; set; }

    public string? StudentComment { get; set; }

    public int SudentLateMinutes { get; set; }

    public decimal? PrepaidAmount { get; set; }
}
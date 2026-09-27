namespace MimosiGeDbPart.Db.Models;

public sealed class LessonByStudent
{
    public int Id { get; set; }

    /// <summary>
    ///     გაკვეთილი
    /// </summary>
    public int LessonId { get; set; }

    /// <summary>
    ///     მოსწავლე
    /// </summary>
    public int StudentContractId { get; set; }

    /// <summary>
    ///     მოსწავლე ჯგუფიდან
    /// </summary>
    public int? GroupByStudentId { get; set; }

    /// <summary>
    ///     საათების რაოდენობა
    /// </summary>
    public float HoursCount { get; set; } = 1f;

    /// <summary>
    ///     დაესწრო გაკვეთილს
    /// </summary>
    public bool Present { get; set; }

    /// <summary>
    ///     თემა
    /// </summary>
    public string? Theme { get; set; }

    /// <summary>
    ///     შეფასება
    /// </summary>
    public float? Rate { get; set; }

    /// <summary>
    ///     მასწავლებლის კომენტარი
    /// </summary>
    public string? TeacherComment { get; set; }

    /// <summary>
    ///     მოსწავლის კომენტარი
    /// </summary>
    public string? StudentComment { get; set; }

    /// <summary>
    ///     მოსწავლემ დაიგვიანა წუთები
    /// </summary>
    public int StudentLateMinutes { get; set; }

    public GroupByStudent? GroupByStudent { get; set; }

    public Lesson Lesson { get; set; } = null!;

    public StudentContract StudentContract { get; set; } = null!;
}

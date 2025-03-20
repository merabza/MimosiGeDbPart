namespace MimosiGeDb.Models;

public class LessonByStudent
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
    public float HoursCount { get; set; }

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
    ///     მოსწავლის კომეტარი
    /// </summary>
    public string? StudentComment { get; set; }

    /// <summary>
    ///     სტუდენთმა დაიგვიანა წუთი
    /// </summary>
    public int SudentLateMinutes { get; set; }

    /// <summary>
    ///     წინასწარ გადახდილი თანხა (ბოლო თვის თანხის შესაბამისი)
    /// </summary>
    public decimal? PrepaidAmount { get; set; }

    public virtual GroupByStudent? GroupByStudent { get; set; }

    public virtual Lesson Lesson { get; set; } = null!;
}
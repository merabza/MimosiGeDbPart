namespace MimosiGeDbPart.Db.Models;

public sealed class StudentContractDetail
{
    public int Id { get; set; }

    /// <summary>
    ///     მოსწავლის კონტრაქტი
    /// </summary>
    public int StudentContractId { get; set; }

    /// <summary>
    ///     საგანი
    /// </summary>
    public int CourseId { get; set; }

    /// <summary>
    ///     ჯგუფის ზომა (ტიპი)
    /// </summary>
    public int GroupSizeId { get; set; }

    /// <summary>
    ///     4 კვირაში საათების რაოდენობა
    /// </summary>
    public float FourWeekHours { get; set; } = 8f;

    /// <summary>
    ///     4 კვირაში გადასახადი
    /// </summary>
    public decimal FourWeekFee { get; set; } = 48m;

    /// <summary>
    ///     ერთი საათის ღირებულება
    /// </summary>
    public decimal OneHourFee { get; set; } = 6m;

    public Course Course { get; set; } = null!;

    public GroupSize GroupSize { get; set; } = null!;

    public StudentContract StudentContract { get; set; } = null!;
}

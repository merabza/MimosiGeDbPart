using System;

namespace MimosiGeDb.Models;

public sealed class StudentContractDetail
{
    public int Id { get; set; }

    public int? StudentContractId { get; set; }

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
    public float FourWeekHours { get; set; }

    /// <summary>
    ///     4 კვირაში გადასახადი
    /// </summary>
    public decimal FourWeekFee { get; set; }

    /// <summary>
    ///     ერთი საათის ღირებულება
    /// </summary>
    public decimal OneHourFee { get; set; }

    private Course? _courseNavigation;
    public Course CourseNavigation
    {
        get =>
            _courseNavigation ??
            throw new InvalidOperationException("Uninitialized property: " + nameof(CourseNavigation));
        set => _courseNavigation = value;
    }

    public GroupSize GroupSize { get; set; } = null!;

    public StudentContract? StudentContract { get; set; }
}
using System;

namespace MimosiGeDb.Models;

public sealed class SalaryLineDetail
{
    private Group? _groupNavigation;

    /// <summary>
    ///     სტრიქონის იდენტიფიკატორი
    /// </summary>
    public int SadId { get; set; }

    /// <summary>
    ///     სათაურის იდენტიფიკატორი
    /// </summary>
    public int SaId { get; set; }

    /// <summary>
    ///     გადასარიცხი თანხა
    /// </summary>
    public decimal SadAmount { get; set; }

    /// <summary>
    ///     ჯგუფი
    /// </summary>
    public int GroupId { get; set; }

    /// <summary>
    ///     საათების რაოდენობა
    /// </summary>
    public float SadHoursCount { get; set; }

    /// <summary>
    ///     ერთი საათის ღირებულება
    /// </summary>
    public decimal SadHourCost { get; set; }

    public Group GroupNavigation
    {
        get =>
            _groupNavigation ??
            throw new InvalidOperationException("Uninitialized property: " + nameof(GroupNavigation));
        set => _groupNavigation = value;
    }

    public SalaryLine Sa { get; set; } = null!;
}
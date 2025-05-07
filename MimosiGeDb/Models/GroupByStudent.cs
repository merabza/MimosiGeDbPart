using System;
using System.Collections.Generic;

namespace MimosiGeDb.Models;

public sealed class GroupByStudent
{
    private StudentContract? _studentContractNavigation;
    public int GbsId { get; set; }

    /// <summary>
    ///     ჯგუფი
    /// </summary>
    public int GroupId { get; set; }

    /// <summary>
    ///     მოსწავლე
    /// </summary>
    public int StudentContractId { get; set; }

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

    /// <summary>
    ///     საათის კოეფიციენტი
    /// </summary>
    public float HoursCoefficient { get; set; }

    /// <summary>
    ///     გააქტიურების თარიღი
    /// </summary>
    public DateTime StartDate { get; set; }

    /// <summary>
    ///     გაუქმების თარიღი
    /// </summary>
    public DateTime? EndDate { get; set; }

    /// <summary>
    ///     შენიშვნა
    /// </summary>
    public string? Note { get; set; }

    /// <summary>
    ///     საჭიროებს დარიცხვების დაზუსტებას
    /// </summary>
    public bool DirtyCharges { get; set; }

    private Group? _groupNavigation;

    public Group GroupNavigation
    {
        get =>
            _groupNavigation ??
            throw new InvalidOperationException("Uninitialized property: " + nameof(GroupNavigation));
        set => _groupNavigation = value;
    }

    public StudentContract StudentContractNavigation
    {
        get =>
            _studentContractNavigation ??
            throw new InvalidOperationException("Uninitialized property: " + nameof(StudentContractNavigation));
        set => _studentContractNavigation = value;
    }

    public ICollection<LessonByStudent> LessonsByStudents { get; set; } = new List<LessonByStudent>();
}
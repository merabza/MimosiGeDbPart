using System;
using System.Collections.Generic;

namespace MimosiGeDbPart.Db.Models;

public sealed class GroupByStudent
{
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
    public float FourWeekHours { get; set; } = 8f;

    /// <summary>
    ///     4 კვირაში გადასახადი
    /// </summary>
    public decimal FourWeekFee { get; set; } = 48m;

    /// <summary>
    ///     ერთი საათის ღირებულება
    /// </summary>
    public decimal OneHourFee { get; set; } = 6m;

    /// <summary>
    ///     საათის კოეფიციენტი
    /// </summary>
    public float HoursCoefficient { get; set; } = 1f;

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

    public Group Group { get; set; } = null!;

    public StudentContract StudentContract { get; set; } = null!;

    public ICollection<LessonByStudent> LessonsByStudents { get; set; } = new List<LessonByStudent>();
}

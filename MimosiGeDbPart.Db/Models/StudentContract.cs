using System;
using System.Collections.Generic;

namespace MimosiGeDbPart.Db.Models;

public sealed class StudentContract
{
    private AcademicYear? _academicYearNavigation;

    private Human? _parentHumanNavigation;

    private Human? _studentHumanNavigation;

    private StudentStatus? _studentStatusNavigation;
    public int ScId { get; set; }

    /// <summary>
    ///     კონტრაქტის ნომერი
    /// </summary>
    public required string ContractNumber { get; set; }

    /// <summary>
    ///     კონტრაქტის თარიღი
    /// </summary>
    public DateTime ContractDate { get; set; }

    /// <summary>
    ///     მოსწავლე
    /// </summary>
    public int StudentHumanId { get; set; }

    /// <summary>
    ///     მშობელი
    /// </summary>
    public int ParentHumanId { get; set; }

    /// <summary>
    ///     სასწავლო წელი
    /// </summary>
    public int AcademicYearId { get; set; }

    /// <summary>
    ///     მოსწავლის სტატუსი
    /// </summary>
    public int? StudentStatusId { get; set; }

    /// <summary>
    ///     გადახდის სასურველი დღე თვეში
    /// </summary>
    public float? DesiredMonthlyPaymentDay { get; set; }

    /// <summary>
    ///     შემდეგი გადახდის თარიღი
    /// </summary>
    public DateTime? NextPayDate { get; set; }

    /// <summary>
    ///     შემდეგი გადახდის თარიღს სჭირდება გადაანგარიშება
    /// </summary>
    public bool DirtyNextPayDate { get; set; }

    public AcademicYear AcademicYearNavigation
    {
        get =>
            _academicYearNavigation ??
            throw new InvalidOperationException("Uninitialized property: " + nameof(_academicYearNavigation));
        set => _academicYearNavigation = value;
    }

    public Human ParentHumanNavigation
    {
        get =>
            _parentHumanNavigation ??
            throw new InvalidOperationException("Uninitialized property: " + nameof(_parentHumanNavigation));
        set => _parentHumanNavigation = value;
    }

    public Human StudentHumanNavigation
    {
        get =>
            _studentHumanNavigation ??
            throw new InvalidOperationException("Uninitialized property: " + nameof(_studentHumanNavigation));
        set => _studentHumanNavigation = value;
    }

    public StudentStatus StudentStatusNavigation
    {
        get =>
            _studentStatusNavigation ??
            throw new InvalidOperationException("Uninitialized property: " + nameof(_studentStatusNavigation));
        set => _studentStatusNavigation = value;
    }

    public ICollection<CrmCall> CrmCalls { get; set; } = new List<CrmCall>();

    public ICollection<Payment> Payments { get; set; } = new List<Payment>();

    public ICollection<StudentContractDetail> StudentContractDetails { get; set; } = new List<StudentContractDetail>();

    public ICollection<SummaryComment> SummaryComments { get; set; } = new List<SummaryComment>();
}

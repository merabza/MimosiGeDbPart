using System;
using System.Collections.Generic;

namespace MimosiGeDb.Models;

public sealed class StudentContract
{
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
    public int StudentHid { get; set; }

    /// <summary>
    ///     მშობელი
    /// </summary>
    public int ParentHid { get; set; }

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

    private AcademicYear? _academicYearNavigation;

    public AcademicYear AcademicYearNavigation
    {
        get =>
            _academicYearNavigation ??
            throw new InvalidOperationException("Uninitialized property: " + nameof(_academicYearNavigation));
        set => _academicYearNavigation = value;
    }

    private Human? _parentHumanNavigation;

    public Human ParentHumanNavigation
    {
        get =>
            _parentHumanNavigation ??
            throw new InvalidOperationException("Uninitialized property: " + nameof(_parentHumanNavigation));
        set => _parentHumanNavigation = value;
    }

    private Human? _studentHumanNavigation;

    public Human StudentHumanNavigation
    {
        get =>
            _studentHumanNavigation ??
            throw new InvalidOperationException("Uninitialized property: " + nameof(_studentHumanNavigation));
        set => _studentHumanNavigation = value;
    }

    private StudentStatus? _studentStatusNavigation;

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
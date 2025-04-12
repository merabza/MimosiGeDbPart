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

    public AcademicYear AcademicYear { get; set; } = null!;

    public ICollection<CrmCall> CrmCalls { get; set; } = new List<CrmCall>();

    public Human ParentH { get; set; } = null!;

    public ICollection<Payment> Payments { get; set; } = new List<Payment>();

    public ICollection<StudentContractDetail> StudentContractDetails { get; set; } = new List<StudentContractDetail>();

    public Human StudentH { get; set; } = null!;

    public StudentStatus? StudentStatus { get; set; }

    public ICollection<SummaryComment> SummaryComments { get; set; } = new List<SummaryComment>();
}
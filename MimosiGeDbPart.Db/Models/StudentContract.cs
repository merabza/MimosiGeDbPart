using System;
using System.Collections.Generic;

namespace MimosiGeDbPart.Db.Models;

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
    public int? DesiredMonthlyPaymentDay { get; set; }

    /// <summary>
    ///     შემდეგი გადახდის თარიღი
    /// </summary>
    public DateTime? NextPayDate { get; set; }

    /// <summary>
    ///     შემდეგი გადახდის თარიღს სჭირდება გადაანგარიშება
    /// </summary>
    public bool DirtyNextPayDate { get; set; } = true;

    public AcademicYear AcademicYear { get; set; } = null!;

    public Human ParentHuman { get; set; } = null!;

    public Human StudentHuman { get; set; } = null!;

    public StudentStatus? StudentStatus { get; set; }

    public ICollection<CrmCall> CrmCalls { get; set; } = new List<CrmCall>();

    public ICollection<GroupByStudent> GroupsByStudents { get; set; } = new List<GroupByStudent>();

    public ICollection<LessonByStudent> LessonsByStudents { get; set; } = new List<LessonByStudent>();

    public ICollection<Payment> Payments { get; set; } = new List<Payment>();

    public ICollection<StudentContractDetail> StudentContractDetails { get; set; } = new List<StudentContractDetail>();
}

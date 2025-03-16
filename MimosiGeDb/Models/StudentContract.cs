using System;
using System.Collections.Generic;

namespace MimosiGeDb.Models;

public class StudentContract
{
    public int ScId { get; set; }

    /// <summary>
    /// კონტრაქტის ნომერი
    /// </summary>
    public required string ContractNumber { get; set; }

    /// <summary>
    /// კონტრაქტის თარიღი
    /// </summary>
    public DateTime ContractDate { get; set; }

    /// <summary>
    /// მოსწავლე
    /// </summary>
    public int StudentHid { get; set; }

    /// <summary>
    /// მშობელი
    /// </summary>
    public int ParentHid { get; set; }

    /// <summary>
    /// სასწავლო წელი
    /// </summary>
    public int AcademicYearId { get; set; }

    /// <summary>
    /// მოსწავლის სტატუსი
    /// </summary>
    public int? StudentStatusId { get; set; }

    /// <summary>
    /// გადახდის სასურველი დღე თვეში
    /// </summary>
    public float? DesiredMonthlyPaymentDay { get; set; }

    /// <summary>
    /// შემდეგი გადახდის თარიღი
    /// </summary>
    public DateTime? NextPayDate { get; set; }

    /// <summary>
    /// შემდეგი გადახდის თარიღს სჭირდება გადაანგარიშება
    /// </summary>
    public bool DirtyNextPayDate { get; set; }

    public virtual AcademicYear AcademicYear { get; set; } = null!;

    public virtual ICollection<CrmCall> CrmCalls { get; set; } = new List<CrmCall>();

    public virtual Humans ParentH { get; set; } = null!;

    public virtual ICollection<Payments> Payments { get; set; } = new List<Payments>();

    public virtual ICollection<StudentContractDetails> StudentContractDetails { get; set; } =
        new List<StudentContractDetails>();

    public virtual Humans StudentH { get; set; } = null!;

    public virtual StudentStatus? StudentStatus { get; set; }

    public virtual ICollection<SummaryComments> SummaryComments { get; set; } = new List<SummaryComments>();
}
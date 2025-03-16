using System;
using System.Collections.Generic;

namespace MimosiGeDb.Models;

public partial class TeacherContracts
{
    public int Id { get; set; }

    /// <summary>
    /// კონტრაქტის ნომერი
    /// </summary>
    public string ContractNumber { get; set; } = null!;

    /// <summary>
    /// კონტრაქტის თარიღი
    /// </summary>
    public DateTime ContractDate { get; set; }

    /// <summary>
    /// მასწავლებელი
    /// </summary>
    public int TeacherHid { get; set; }

    /// <summary>
    /// ანგარიშის ნომერი
    /// </summary>
    public string? BankAccount { get; set; }

    /// <summary>
    /// ბანკის კოდი
    /// </summary>
    public string? BankAccountCode { get; set; }

    /// <summary>
    /// მონაწილეობს სახელფასო პროგრამაში
    /// </summary>
    public bool SalaryProgram { get; set; }

    /// <summary>
    /// მონაწილეობს საპენსიო სქემაში
    /// </summary>
    public bool PensionScema { get; set; }

    /// <summary>
    /// განაცემის სახე (საგადასახადოსათვის)
    /// </summary>
    public short? RsQuoteId { get; set; }

    /// <summary>
    /// ქვეყანა (საგადასახადოსათვის)
    /// </summary>
    public int RsCountryId { get; set; }

    /// <summary>
    /// განაცემის ყოველთვიური ფიქსირებული რაოდენობა
    /// </summary>
    public decimal FixedAmount { get; set; }

    /// <summary>
    /// კონტრაქტის დასრულების თარიღი
    /// </summary>
    public DateTime? ContractEndDate { get; set; }

    /// <summary>
    /// განაცემი ეკუთვნის შემდეგ თვეს
    /// </summary>
    public bool NextMonth { get; set; }

    /// <summary>
    /// განაცემის შინაარსი (თუ ხელფასი არ არის)
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// ხელფასის ძირითადი სქემა საათობრივი ანაზღაურებისათვის
    /// </summary>
    public int? SalarySchemaByHours { get; set; }

    /// <summary>
    /// სამუშაო საათების ჯგუფი
    /// </summary>
    public int? WorkHourGroupId { get; set; }

    /// <summary>
    /// სამუშაოს დაწყება
    /// </summary>
    public DateTime? WorkHoursStart { get; set; }

    /// <summary>
    /// სამუშაოს დასრულება
    /// </summary>
    public DateTime? WorkHoursEnd { get; set; }

    public short? Line { get; set; }

    /// <summary>
    /// ინდივიდუალური მეწარმე
    /// </summary>
    public bool IndEnt { get; set; }

    public virtual ICollection<FinancedStudies> FinancedStudies { get; set; } = new List<FinancedStudies>();

    public virtual ICollection<Lessons> LessonsSubstituteTeacherContract { get; set; } = new List<Lessons>();

    public virtual ICollection<Lessons> LessonsTeacherContract { get; set; } = new List<Lessons>();

    public virtual RsCountries RsCountry { get; set; } = null!;

    public virtual RsQuoteTypes? RsQuote { get; set; }

    public virtual ICollection<SalaryCharges> SalaryCharges { get; set; } = new List<SalaryCharges>();

    public virtual ICollection<SalaryLines> SalaryLines { get; set; } = new List<SalaryLines>();

    public virtual ICollection<SalaryParts> SalaryParts { get; set; } = new List<SalaryParts>();

    public virtual TeacherSalarySchemes? SalarySchemaByHoursNavigation { get; set; }

    public virtual ICollection<SummaryComments> SummaryComments { get; set; } = new List<SummaryComments>();

    public virtual Humans TeacherH { get; set; } = null!;

    public virtual WorkHourGroups? WorkHourGroup { get; set; }

    public virtual ICollection<WorkHours> WorkHours { get; set; } = new List<WorkHours>();
}
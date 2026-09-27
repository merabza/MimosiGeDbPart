using System;
using System.Collections.Generic;

namespace MimosiGeDbPart.Db.Models;

public sealed class TeacherContract
{
    public int Id { get; set; }

    /// <summary>
    ///     კონტრაქტის ნომერი
    /// </summary>
    public string ContractNumber { get; set; } = null!;

    /// <summary>
    ///     კონტრაქტის თარიღი
    /// </summary>
    public DateTime ContractDate { get; set; }

    /// <summary>
    ///     მასწავლებელი
    /// </summary>
    public int TeacherHumanId { get; set; }

    /// <summary>
    ///     ანგარიშის ნომერი
    /// </summary>
    public string? BankAccount { get; set; }

    /// <summary>
    ///     ბანკის კოდი
    /// </summary>
    public string? BankAccountCode { get; set; }

    /// <summary>
    ///     მონაწილეობს საპენსიო სქემაში
    /// </summary>
    public bool PensionScheme { get; set; }

    /// <summary>
    ///     განაცემის სახე (საგადასახადოსათვის)
    /// </summary>
    public int? RsQuoteTypeId { get; set; }

    /// <summary>
    ///     ქვეყანა (საგადასახადოსათვის)
    /// </summary>
    public int RsCountryId { get; set; }

    /// <summary>
    ///     განაცემის ყოველთვიური ფიქსირებული რაოდენობა
    /// </summary>
    public decimal FixedAmount { get; set; }

    /// <summary>
    ///     კონტრაქტის დასრულების თარიღი
    /// </summary>
    public DateTime? ContractEndDate { get; set; }

    /// <summary>
    ///     განაცემი ეკუთვნის შემდეგ თვეს
    /// </summary>
    public bool NextMonth { get; set; }

    /// <summary>
    ///     განაცემის შინაარსი (თუ ხელფასი არ არის)
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    ///     ხელფასის ძირითადი სქემა საათობრივი ანაზღაურებისათვის
    /// </summary>
    public int? SalarySchemaByHoursId { get; set; }

    /// <summary>
    ///     სამუშაო საათების ჯგუფი
    /// </summary>
    public int? WorkHourGroupId { get; set; }

    /// <summary>
    ///     სამუშაოს დაწყება
    /// </summary>
    public DateTime? WorkHoursStart { get; set; }

    /// <summary>
    ///     სამუშაოს დასრულება
    /// </summary>
    public DateTime? WorkHoursEnd { get; set; }

    /// <summary>
    ///     დროის ხაზი (რეპორტი r35)
    /// </summary>
    public int Line { get; set; }

    /// <summary>
    ///     ინდივიდუალური მეწარმე
    /// </summary>
    public bool IndEnt { get; set; }

    public ICollection<GroupByTeacher> GroupsByTeachers { get; set; } = new List<GroupByTeacher>();

    public ICollection<Lesson> LessonsSubstituteTeacherContract { get; set; } = new List<Lesson>();

    public ICollection<Lesson> LessonsTeacherContract { get; set; } = new List<Lesson>();

    public RsCountry RsCountry { get; set; } = null!;

    public RsQuoteType? RsQuoteType { get; set; }

    public ICollection<SalaryLine> SalaryLines { get; set; } = new List<SalaryLine>();

    public ICollection<SalaryPart> SalaryParts { get; set; } = new List<SalaryPart>();

    public TeacherSalaryScheme? SalarySchemaByHours { get; set; }

    public Human TeacherHuman { get; set; } = null!;

    public WorkHourGroup? WorkHourGroup { get; set; }

    public ICollection<WorkHour> WorkHours { get; set; } = new List<WorkHour>();
}

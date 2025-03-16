using System;
using System.Collections.Generic;

namespace MimosiGeDb.Models;

public partial class Lessons
{
    public int Id { get; set; }

    /// <summary>
    /// ჯგუფი
    /// </summary>
    public int GroupId { get; set; }

    /// <summary>
    /// მასწავლებელი
    /// </summary>
    public int TeacherContractId { get; set; }

    /// <summary>
    /// შემცვლელი მასწავლებელი
    /// </summary>
    public int? SubstituteTeacherContractId { get; set; }

    /// <summary>
    /// ჩატარების თარიღი და დრო
    /// </summary>
    public DateTime LessonDt { get; set; }

    /// <summary>
    /// ხელფასის სქემა
    /// </summary>
    public int SalarySchemaId { get; set; }

    /// <summary>
    /// 4 კვირაში საათების რაოდენობა
    /// </summary>
    public float FourWeekHours { get; set; }

    /// <summary>
    /// გაკვეთილის ჩატარების სტატუსი
    /// </summary>
    public int Status { get; set; }

    /// <summary>
    /// შენიშვნა
    /// </summary>
    public string? Note { get; set; }

    /// <summary>
    /// მასწავლებელმა დაიგვიანა წუთები
    /// </summary>
    public int TeacherLateMinutes { get; set; }

    /// <summary>
    /// აღდგენა
    /// </summary>
    public DateTime? RecoverDate { get; set; }

    /// <summary>
    /// ჯგუფში დროების განაწილების მიხედვით თეორიულად მინმალური თარიღი იმ თვისთვის, როცა ეს გაკვეთილი ჩატარდა
    /// </summary>
    public DateTime TeoMinDate { get; set; }

    /// <summary>
    /// ჯგუფში დროების განაწილების მიხედვით თეორიულად მაქსიმალური თარიღი იმ თვისთვის, როცა ეს გაკვეთილი ჩატარდა
    /// </summary>
    public DateTime TeoMaxDate { get; set; }

    public virtual Group Group { get; set; } = null!;

    public virtual ICollection<LessonMaterial> LessonBooksAndMaterials { get; set; } =
        new List<LessonMaterial>();

    public virtual ICollection<LessonsByStudents> LessonsByStudents { get; set; } = new List<LessonsByStudents>();

    public virtual ICollection<LessonsCheckCreateErrorLogs> LessonsCheckCreateErrorLogs { get; set; } =
        new List<LessonsCheckCreateErrorLogs>();

    public virtual LessonStatuses StatusNavigation { get; set; } = null!;

    public virtual TeacherContracts? SubstituteTeacherContract { get; set; }

    public virtual TeacherContracts TeacherContract { get; set; } = null!;
}
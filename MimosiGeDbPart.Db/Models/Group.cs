using System;
using System.Collections.Generic;

namespace MimosiGeDbPart.Db.Models;

public sealed class Group
{
    public int GrpId { get; set; }

    /// <summary>
    ///     სასწავლო წელი
    /// </summary>
    public int AcademicYearId { get; set; }

    /// <summary>
    ///     ჯგუფის კოდი
    /// </summary>
    public required string GroupCode { get; set; }

    /// <summary>
    ///     საგანი
    /// </summary>
    public int CourseId { get; set; }

    /// <summary>
    ///     ჯგუფის ზომა (ტიპი)
    /// </summary>
    public int GroupSizeId { get; set; } = 2;

    /// <summary>
    ///     საჭიროებს გაკვეთილების დაზუსტებას
    /// </summary>
    public bool DirtyLessons { get; set; } = true;

    /// <summary>
    ///     მოსწავლის სტატუსი
    /// </summary>
    public int StudentStatusId { get; set; }

    /// <summary>
    ///     გაუქმების თარიღი
    /// </summary>
    public DateTime? VoidDate { get; set; }

    public AcademicYear AcademicYear { get; set; } = null!;

    public Course Course { get; set; } = null!;

    public GroupSize GroupSize { get; set; } = null!;

    public StudentStatus StudentStatus { get; set; } = null!;

    public ICollection<GroupDayTimePlace> GroupDayTimePlaces { get; set; } = new List<GroupDayTimePlace>();
    public ICollection<GroupByStudent> GroupsByStudents { get; set; } = new List<GroupByStudent>();
    public ICollection<GroupByTeacher> GroupsByTeachers { get; set; } = new List<GroupByTeacher>();
    public ICollection<Lesson> Lessons { get; set; } = new List<Lesson>();

    public ICollection<LessonCheckCreateErrorLog> LessonsCheckCreateErrorLogs { get; set; } =
        new List<LessonCheckCreateErrorLog>();

    public ICollection<SalaryLineDetail> SalaryLinesDetails { get; set; } = new List<SalaryLineDetail>();
}

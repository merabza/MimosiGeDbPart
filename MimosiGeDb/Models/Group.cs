using System;
using System.Collections.Generic;

namespace MimosiGeDb.Models;

public class Group
{
    private Course? _courseNavigation;

    private GroupSize? _groupSizeNavigation;

    private StudentStatus? _studentStatusNavigation;
    public int GrpId { get; set; }

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
    public int GroupSizeId { get; set; }

    /// <summary>
    ///     საჭიროებს გაკვეთილების დაზუსტებას
    /// </summary>
    public bool DirtyLessons { get; set; }

    /// <summary>
    ///     მოსწავლის სტატუსი
    /// </summary>
    public int StudentStatusId { get; set; }

    /// <summary>
    ///     გაუქმების თარიღი
    /// </summary>
    public DateTime? VoidDate { get; set; }

    public Course CourseNavigation
    {
        get =>
            _courseNavigation ??
            throw new InvalidOperationException("Uninitialized property: " + nameof(CourseNavigation));
        set => _courseNavigation = value;
    }

    public GroupSize GroupSizeNavigation
    {
        get =>
            _groupSizeNavigation ??
            throw new InvalidOperationException("Uninitialized property: " + nameof(GroupSizeNavigation));
        set => _groupSizeNavigation = value;
    }

    public StudentStatus StudentStatusNavigation
    {
        get =>
            _studentStatusNavigation ??
            throw new InvalidOperationException("Uninitialized property: " + nameof(StudentStatusNavigation));
        set => _studentStatusNavigation = value;
    }

    public ICollection<GroupMaterial> GroupMaterials { get; set; } = new List<GroupMaterial>();

    public ICollection<GroupDayTimePlace> GroupDayTimePlace { get; set; } = new List<GroupDayTimePlace>();

    public ICollection<GroupsByStudent> GroupsByStudents { get; set; } = new List<GroupsByStudent>();

    public ICollection<GroupsByTeachers> GroupsByTeachers { get; set; } = new List<GroupsByTeachers>();

    public ICollection<Lessons> Lessons { get; set; } = new List<Lessons>();

    public ICollection<LessonsCheckCreateErrorLogs> LessonsCheckCreateErrorLogs { get; set; } =
        new List<LessonsCheckCreateErrorLogs>();

    public ICollection<SalaryLineDetail> SalaryLinesDetails { get; set; } = new List<SalaryLineDetail>();
}
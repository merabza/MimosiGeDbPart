﻿namespace MimosiGeDb.Models;

public sealed class SummaryComment
{
    public int Id { get; set; }

    /// <summary>
    ///     საგანი
    /// </summary>
    public int CourseId { get; set; }

    /// <summary>
    ///     მასწავლებელი
    /// </summary>
    public int TeacherContractId { get; set; }

    /// <summary>
    ///     მოსწავლე
    /// </summary>
    public int StudentContractId { get; set; }

    /// <summary>
    ///     თვე
    /// </summary>
    public int OperationMonthDateId { get; set; }

    /// <summary>
    ///     კომენტარი
    /// </summary>
    public string? CommentText { get; set; }

    public Course Course { get; set; } = null!;

    public OperationMonth OperationMonthDate { get; set; } = null!;

    public StudentContract StudentContract { get; set; } = null!;

    public TeacherContract TeacherContract { get; set; } = null!;
}
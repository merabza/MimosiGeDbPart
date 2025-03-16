﻿namespace MimosiGeDb.Models;

public partial class SummaryComments
{
    public int Id { get; set; }

    /// <summary>
    /// საგანი
    /// </summary>
    public int CourseId { get; set; }

    /// <summary>
    /// მასწავლებელი
    /// </summary>
    public int TeacherContractId { get; set; }

    /// <summary>
    /// მოსწავლე
    /// </summary>
    public int StudentContractId { get; set; }

    /// <summary>
    /// თვე
    /// </summary>
    public int OperationMonthDateId { get; set; }

    /// <summary>
    /// კომენტარი
    /// </summary>
    public string? CommentText { get; set; }

    public virtual Courses Course { get; set; } = null!;

    public virtual OperationMonths OperationMonthDate { get; set; } = null!;

    public virtual StudentContract StudentContract { get; set; } = null!;

    public virtual TeacherContracts TeacherContract { get; set; } = null!;
}
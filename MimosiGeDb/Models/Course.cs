using System.Collections.Generic;

namespace MimosiGeDb.Models;

public class Course
{
    public int CrsId { get; set; }

    /// <summary>
    ///     კურსის, საგნის სახელი
    /// </summary>
    public required string CourseName { get; set; }

    public ICollection<Group> Groups { get; set; } = new List<Group>();

    public ICollection<StudentContractDetails> StudentContractDetails { get; set; } =
        new List<StudentContractDetails>();

    public ICollection<SummaryComments> SummaryComments { get; set; } = new List<SummaryComments>();
}
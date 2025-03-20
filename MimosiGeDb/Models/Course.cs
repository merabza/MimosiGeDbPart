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

    public ICollection<StudentContractDetail> StudentContractDetails { get; set; } = new List<StudentContractDetail>();

    public ICollection<SummaryComment> SummaryComments { get; set; } = new List<SummaryComment>();
}
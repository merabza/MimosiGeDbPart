using System.Collections.Generic;

namespace MimosiGeDb.Models;

public sealed class GroupSize
{
    public int GrsId { get; set; }
    public int? GrsSize { get; set; }
    public string? GrsName { get; set; }
    public ICollection<Group> Groups { get; set; } = new List<Group>();
    public ICollection<StudentContractDetail> StudentContractDetails { get; set; } = new List<StudentContractDetail>();
}
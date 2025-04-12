using System.Collections.Generic;

namespace MimosiGeDb.Models;

public sealed class GroupSize
{
    public int Id { get; set; }

    public short? Size { get; set; }

    public string? Name { get; set; }

    public ICollection<Group> Groups { get; set; } = new List<Group>();

    public ICollection<StudentContractDetail> StudentContractDetails { get; set; } = new List<StudentContractDetail>();
}
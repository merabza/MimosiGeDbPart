using System.Collections.Generic;

namespace MimosiGeDb.Models;

public class GroupSize
{
    public int Id { get; set; }

    public short? Size { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<Group> Groups { get; set; } = new List<Group>();

    public virtual ICollection<StudentContractDetail> StudentContractDetails { get; set; } =
        new List<StudentContractDetail>();
}
using System.Collections.Generic;

namespace MimosiGeDb.Models;

public class GroupSize
{
    public int Id { get; set; }

    public short? Size { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<Group> Groups { get; set; } = new List<Group>();

    public virtual ICollection<StudentContractDetails> StudentContractDetails { get; set; } =
        new List<StudentContractDetails>();
}
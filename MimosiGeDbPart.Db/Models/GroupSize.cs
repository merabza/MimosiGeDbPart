using System.Collections.Generic;

namespace MimosiGeDbPart.Db.Models;

public sealed class GroupSize
{
    public int GrsId { get; set; }

    /// <summary>
    ///     ადგილების რაოდენობა ჯგუფში
    /// </summary>
    public int GrsSize { get; set; }

    /// <summary>
    ///     ჯგუფის ზომის დასახელება
    /// </summary>
    public required string GrsName { get; set; }

    public ICollection<Group> Groups { get; set; } = new List<Group>();
    public ICollection<StudentContractDetail> StudentContractDetails { get; set; } = new List<StudentContractDetail>();
}

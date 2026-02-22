using System.Collections.Generic;

namespace MimosiGeDbPart.Db.Models;

public sealed class StudentStatus
{
    public int Id { get; set; }

    /// <summary>
    ///     მოსწავლის სტატუსის სახელი
    /// </summary>
    public string StudentStatusName { get; set; }

    public int? Rate { get; set; }

    public ICollection<Group> Groups { get; set; } = new List<Group>();

    public ICollection<StudentContract> StudentContracts { get; set; } = new List<StudentContract>();
}

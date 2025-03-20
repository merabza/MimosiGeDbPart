using System.Collections.Generic;

namespace MimosiGeDb.Models;

public class StudentStatus
{
    public int Id { get; set; }

    /// <summary>
    ///     მოსწავლის სტატუსის სახელი
    /// </summary>
    public string StudentStatusName { get; set; }

    public int? Rate { get; set; }

    public virtual ICollection<Group> Groups { get; set; } = new List<Group>();

    public virtual ICollection<StudentContract> StudentContracts { get; set; } = new List<StudentContract>();
}
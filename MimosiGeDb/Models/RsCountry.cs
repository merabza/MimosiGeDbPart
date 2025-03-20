using System.Collections.Generic;

namespace MimosiGeDb.Models;

public class RsCountry
{
    public int Id { get; set; }

    public string? Code { get; set; }

    public string? CountryName { get; set; }

    public virtual ICollection<TeacherContract> TeacherContracts { get; set; } = new List<TeacherContract>();
}
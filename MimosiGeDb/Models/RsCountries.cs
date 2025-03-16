using System.Collections.Generic;

namespace MimosiGeDb.Models;

public partial class RsCountries
{
    public int Id { get; set; }

    public string? Code { get; set; }

    public string? CountryName { get; set; }

    public virtual ICollection<TeacherContracts> TeacherContracts { get; set; } = new List<TeacherContracts>();
}
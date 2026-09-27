using System.Collections.Generic;

namespace MimosiGeDbPart.Db.Models;

public sealed class RsCountry
{
    public int Id { get; set; }

    /// <summary>
    ///     ქვეყნის კოდი (შემოსავლების სამსახურის)
    /// </summary>
    public required string Code { get; set; }

    /// <summary>
    ///     ქვეყნის დასახელება
    /// </summary>
    public required string CountryName { get; set; }

    public ICollection<TeacherContract> TeacherContracts { get; set; } = new List<TeacherContract>();
}

using System;

namespace MimosiGeDb.Models;

public partial class GroupBookOrMaterial
{
    public int Id { get; set; }

    public int? GroupId { get; set; }

    public int BmId { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime? EndDate { get; set; }
}
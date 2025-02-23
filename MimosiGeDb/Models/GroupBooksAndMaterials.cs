using System;

namespace MimosiGeDb.Models;

public partial class GroupBooksAndMaterials
{
    public int Id { get; set; }

    public int? GroupId { get; set; }

    public int BmId { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime? EndDate { get; set; }
}
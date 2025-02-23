using System;

namespace MimosiGeDb.Models;

public partial class Groups
{
    public int Id { get; set; }

    public string GroupCode { get; set; } = null!;

    public int CourceId { get; set; }

    public int GroupSizeId { get; set; }

    public bool DirtyLessons { get; set; }

    public int StudentStatusId { get; set; }

    public DateTime? VoidDate { get; set; }
}
namespace MimosiGeDb.Models;

public partial class SalaryParts
{
    public int SpId { get; set; }

    public int ShId { get; set; }

    public int TeacherContractId { get; set; }

    public int? SpSalaryPartType { get; set; }

    public decimal? SpAmount { get; set; }
}
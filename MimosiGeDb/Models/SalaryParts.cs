namespace MimosiGeDb.Models;

public partial class SalaryParts
{
    public int SpId { get; set; }

    /// <summary>
    /// სათაურის იდენტიფიკატორი
    /// </summary>
    public int ShId { get; set; }

    /// <summary>
    /// თანამშრომელი
    /// </summary>
    public int TeacherContractId { get; set; }

    /// <summary>
    /// ხელფასის მდგენელის ტიპი
    /// </summary>
    public int? SpSalaryPartType { get; set; }

    /// <summary>
    /// თანხა (მინუსი ნიშნავს გამოკლებას)
    /// </summary>
    public decimal? SpAmount { get; set; }

    public virtual SalaryHeaders Sh { get; set; } = null!;

    public virtual SalaryPartTypes? SpSalaryPartTypeNavigation { get; set; }

    public virtual TeacherContracts TeacherContract { get; set; } = null!;
}
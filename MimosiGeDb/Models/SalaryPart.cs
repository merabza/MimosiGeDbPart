namespace MimosiGeDb.Models;

public sealed class SalaryPart
{
    public int SpId { get; set; }

    /// <summary>
    ///     სათაურის იდენტიფიკატორი
    /// </summary>
    public int ShId { get; set; }

    /// <summary>
    ///     თანამშრომელი
    /// </summary>
    public int TeacherContractId { get; set; }

    /// <summary>
    ///     ხელფასის მდგენელის ტიპი
    /// </summary>
    public int? SpSalaryPartType { get; set; }

    /// <summary>
    ///     თანხა (მინუსი ნიშნავს გამოკლებას)
    /// </summary>
    public decimal? SpAmount { get; set; }

    public SalaryHeader Sh { get; set; } = null!;

    public SalaryPartType? SpSalaryPartTypeNavigation { get; set; }

    public TeacherContract TeacherContract { get; set; } = null!;
}
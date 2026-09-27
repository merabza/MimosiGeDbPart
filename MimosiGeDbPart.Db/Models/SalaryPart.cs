namespace MimosiGeDbPart.Db.Models;

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
    public int? SalaryPartTypeId { get; set; }

    /// <summary>
    ///     თანხა (მინუსი ნიშნავს გამოკლებას)
    /// </summary>
    public decimal SpAmount { get; set; }

    public SalaryHeader SalaryHeader { get; set; } = null!;

    public SalaryPartType? SalaryPartType { get; set; }

    public TeacherContract TeacherContract { get; set; } = null!;
}

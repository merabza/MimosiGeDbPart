namespace MimosiGeDbPart.Db.Models;

public sealed class SalaryChargeChange
{
    public int Id { get; set; }

    /// <summary>
    ///     დარიცხვის ჩანაწერი
    /// </summary>
    public int SalaryChargeId { get; set; }

    /// <summary>
    ///     გადასახდელი თანხა
    /// </summary>
    public double Amount { get; set; }

    public SalaryCharge SalaryCharge { get; set; } = null!;
}

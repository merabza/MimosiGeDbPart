namespace MimosiGeDb.Models;

public class SalaryChargeChange
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

    public virtual SalaryCharge SalaryCharge { get; set; } = null!;
}
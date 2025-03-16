namespace MimosiGeDb.Models;

public partial class SalaryChargesChanges
{
    public int Id { get; set; }

    /// <summary>
    /// დარიცხვის ჩანაწერი
    /// </summary>
    public int SalaryChargeId { get; set; }

    /// <summary>
    /// გადასახდელი თანხა
    /// </summary>
    public double Amount { get; set; }

    public virtual SalaryCharges SalaryCharge { get; set; } = null!;
}
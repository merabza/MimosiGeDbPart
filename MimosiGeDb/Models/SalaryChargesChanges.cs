namespace MimosiGeDb.Models;

public partial class SalaryChargesChanges
{
    public int Id { get; set; }

    public int SalaryChargeId { get; set; }

    public double Amount { get; set; }
}
namespace MimosiGeDb.Models;

public partial class BankAccounts
{
    public int Id { get; set; }

    public string BankName { get; set; } = null!;

    public string BankCode { get; set; } = null!;

    public string? AccountNumber { get; set; }

    public bool DesperateDebt { get; set; }
}
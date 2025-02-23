namespace MimosiGeDb.Models;

public partial class Stuff
{
    public int Id { get; set; }

    public int HumanId { get; set; }

    public string BankAccount { get; set; } = null!;

    public string? BankAccountCode { get; set; }

    public bool SalaryProgram { get; set; }
}
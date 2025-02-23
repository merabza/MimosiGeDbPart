using System;

namespace MimosiGeDb.Models;

public partial class Payments
{
    public int Id { get; set; }

    public int StudentContractId { get; set; }

    public DateTime PayDate { get; set; }

    public double Amount { get; set; }

    public string? Document { get; set; }

    public int? BankAccountId { get; set; }

    public bool Checked { get; set; }

    public DateTime? ValidFromDate { get; set; }
}
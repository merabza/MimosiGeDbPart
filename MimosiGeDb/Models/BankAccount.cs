using System.Collections.Generic;

namespace MimosiGeDb.Models;

public class BankAccount
{
    public int BaId { get; set; }

    /// <summary>
    ///     ბანკის სახელი
    /// </summary>
    public required string BankName { get; set; }

    /// <summary>
    ///     ბანკის კოდი
    /// </summary>
    public required string BankCode { get; set; }

    /// <summary>
    ///     ორგანიზაციის ანგარიშის ნომერი
    /// </summary>
    public required string AccountNumber { get; set; }

    /// <summary>
    ///     უიმედო ვალი
    /// </summary>
    public bool DesperateDebt { get; set; }

    public ICollection<Payment> Payments { get; set; } = new List<Payment>();
}
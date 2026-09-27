using System;

namespace MimosiGeDbPart.Db.Models;

public sealed class Payment
{
    public int Id { get; set; }

    /// <summary>
    ///     კონტრაქტი
    /// </summary>
    public int StudentContractId { get; set; }

    /// <summary>
    ///     გადახდის თარიღი
    /// </summary>
    public DateTime PayDate { get; set; }

    /// <summary>
    ///     გადახდილი თანხა
    /// </summary>
    public decimal Amount { get; set; }

    /// <summary>
    ///     დოკუმენტი
    /// </summary>
    public string? Document { get; set; }

    /// <summary>
    ///     ბანკის ანგარიში, სადაც შეიტანეს თანხა
    /// </summary>
    public int? BankAccountId { get; set; }

    /// <summary>
    ///     შემოწმებულია
    /// </summary>
    public bool Checked { get; set; }

    public BankAccount? BankAccount { get; set; }

    public StudentContract StudentContract { get; set; } = null!;
}

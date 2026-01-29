using System;

namespace MimosiGeDb.Models;

public sealed class Payment
{
    private BankAccount? _bankAccountNavigation;
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
    public double Amount { get; set; }

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

    /// <summary>
    ///     მოქმედებს თარიღიდან
    /// </summary>
    public DateTime? ValidFromDate { get; set; }

    public BankAccount BankAccountNavigation
    {
        get =>
            _bankAccountNavigation ??
            throw new InvalidOperationException("Uninitialized property: " + nameof(_bankAccountNavigation));
        set => _bankAccountNavigation = value;
    }

    public StudentContract StudentContract { get; set; } = null!;
}

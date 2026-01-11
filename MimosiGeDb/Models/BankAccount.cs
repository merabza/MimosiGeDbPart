using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using CarcassMasterData;

namespace MimosiGeDb.Models;

public sealed class BankAccount : IDataType
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

    //[NotMapped] public static string DtKeyKey => nameof(BaId).CountDtKey();

    [NotMapped]
    public int Id
    {
        get => BaId;
        set => BaId = value;
    }

    [NotMapped] public string? Key => BankCode;

    [NotMapped] public string Name => BankName;

    [NotMapped] public int? ParentId => null;

    public bool UpdateTo(IDataType data)
    {
        if (data is not BankAccount other)
            return false;

        return BaId == other.BaId && BankName == other.BankName && BankCode == other.BankCode &&
               AccountNumber == other.AccountNumber && DesperateDebt == other.DesperateDebt;
    }

    public dynamic EditFields()
    {
        return new BankAccount
        {
            BaId = BaId,
            BankName = BankName,
            BankCode = BankCode,
            AccountNumber = AccountNumber,
            DesperateDebt = DesperateDebt
        };
    }
}
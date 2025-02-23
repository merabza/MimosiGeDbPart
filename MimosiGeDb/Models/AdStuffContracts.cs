using System;

namespace MimosiGeDb.Models;

public partial class AdStuffContracts
{
    public int Id { get; set; }

    public string ContractNumber { get; set; } = null!;

    public DateTime ContractDate { get; set; }

    public int AdStaffHid { get; set; }

    public string? BankAccount { get; set; }

    public string? BankAccountCode { get; set; }

    public float? RsQuoteId { get; set; }

    public int RsCountryId { get; set; }

    public decimal FixedAmount { get; set; }

    public DateTime? ContractEndDate { get; set; }

    public string? Description { get; set; }
}
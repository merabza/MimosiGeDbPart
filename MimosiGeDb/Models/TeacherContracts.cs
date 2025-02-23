using System;

namespace MimosiGeDb.Models;

public partial class TeacherContracts
{
    public int Id { get; set; }

    public string ContractNumber { get; set; } = null!;

    public DateTime ContractDate { get; set; }

    public int TeacherHid { get; set; }

    public string? BankAccount { get; set; }

    public string? BankAccountCode { get; set; }

    public bool SalaryProgram { get; set; }

    public bool PensionScema { get; set; }

    public short? RsQuoteId { get; set; }

    public int RsCountryId { get; set; }

    public decimal FixedAmount { get; set; }

    public DateTime? ContractEndDate { get; set; }

    public bool NextMonth { get; set; }

    public string? Description { get; set; }

    public int? SalarySchemaByHours { get; set; }

    public int? WorkHourGroupId { get; set; }

    public DateTime? WorkHoursStart { get; set; }

    public DateTime? WorkHoursEnd { get; set; }

    public short? Line { get; set; }

    public bool IndEnt { get; set; }
}
using System;

namespace MimosiGeDb.Models;

public partial class SalaryLines
{
    public int SaId { get; set; }

    public int ShId { get; set; }

    public int TeacherContractId { get; set; }

    public decimal SaNetAmountRound { get; set; }

    public decimal SaAmountGross { get; set; }

    public decimal SaPension2 { get; set; }

    public decimal SaGrossMinusPension { get; set; }

    public decimal SaIncomeTax { get; set; }

    public decimal SaGamokvitva { get; set; }

    public decimal SaPension4 { get; set; }

    public decimal SaAmountNet { get; set; }

    public DateTime SaMonthDate { get; set; }

    public short? RsQuoteTypeId { get; set; }

    public decimal SaIndividualIncomeTax { get; set; }
}
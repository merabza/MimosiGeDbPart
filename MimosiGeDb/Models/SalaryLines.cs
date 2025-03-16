﻿using System;
using System.Collections.Generic;

namespace MimosiGeDb.Models;

public partial class SalaryLines
{
    /// <summary>
    /// სტრიქონის იდენტიფიკატორი
    /// </summary>
    public int SaId { get; set; }

    /// <summary>
    /// სათაურის იდენტიფიკატორი
    /// </summary>
    public int ShId { get; set; }

    /// <summary>
    /// კონტრაქტის იდენტიფიკატორი
    /// </summary>
    public int TeacherContractId { get; set; }

    /// <summary>
    /// მთლიანი ნამუშევარი დამრგვალებული 2 ლარზე
    /// </summary>
    public decimal SaNetAmountRound { get; set; }

    /// <summary>
    /// დარიცხული თანხა
    /// </summary>
    public decimal SaAmountGross { get; set; }

    /// <summary>
    /// საპენსიოს 2%
    /// </summary>
    public decimal SaPension2 { get; set; }

    /// <summary>
    /// დარიცხვას გამოკლებული საპენსიო
    /// </summary>
    public decimal SaGrossMinusPension { get; set; }

    /// <summary>
    /// საშემოსავლო
    /// </summary>
    public decimal SaIncomeTax { get; set; }

    /// <summary>
    /// გამოქვითვა
    /// </summary>
    public decimal SaGamokvitva { get; set; }

    /// <summary>
    /// საპენსიოს 4% გადასარიცხი
    /// </summary>
    public decimal SaPension4 { get; set; }

    /// <summary>
    /// გადასარიცხი თანხა
    /// </summary>
    public decimal SaAmountNet { get; set; }

    /// <summary>
    /// დარიცხვის თვე
    /// </summary>
    public DateTime SaMonthDate { get; set; }

    /// <summary>
    /// განაცემის სახე
    /// </summary>
    public short? RsQuoteTypeId { get; set; }

    /// <summary>
    /// ინდივიდუალური საშემოსავლო
    /// </summary>
    public decimal SaIndividualIncomeTax { get; set; }

    public virtual RsQuoteTypes? RsQuoteType { get; set; }

    public virtual ICollection<SalaryLineDetail> SalaryLinesDetails { get; set; } = new List<SalaryLineDetail>();

    public virtual SalaryHeaders Sh { get; set; } = null!;

    public virtual TeacherContracts TeacherContract { get; set; } = null!;
}
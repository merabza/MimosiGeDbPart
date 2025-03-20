using System.Collections.Generic;

namespace MimosiGeDb.Models;

public class SalaryCharge
{
    public int Id { get; set; }

    /// <summary>
    ///     ხელფასის დარიცხვის თვე
    /// </summary>
    public int OpMonthDateId { get; set; }

    /// <summary>
    ///     მასწავლებელი
    /// </summary>
    public int? TeacherContractId { get; set; }

    /// <summary>
    ///     გადასახდელი თანხა
    /// </summary>
    public double Amount { get; set; }

    public virtual OperationMonth OpMonthDate { get; set; } = null!;

    public virtual ICollection<SalaryChargeChange> SalaryChargesChanges { get; set; } = new List<SalaryChargeChange>();

    public virtual TeacherContract? TeacherContract { get; set; }
}
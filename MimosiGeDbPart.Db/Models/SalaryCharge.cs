using System.Collections.Generic;

namespace MimosiGeDbPart.Db.Models;

public sealed class SalaryCharge
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

    public OperationMonth OpMonthDate { get; set; } = null!;

    public ICollection<SalaryChargeChange> SalaryChargesChanges { get; set; } = new List<SalaryChargeChange>();

    public TeacherContract? TeacherContract { get; set; }
}

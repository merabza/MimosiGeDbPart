using System.Collections.Generic;

namespace MimosiGeDb.Models;

public partial class SalaryCharges
{
    public int Id { get; set; }

    /// <summary>
    /// ხელფასის დარიცხვის თვე
    /// </summary>
    public int OpMonthDateId { get; set; }

    /// <summary>
    /// მასწავლებელი
    /// </summary>
    public int? TeacherContractId { get; set; }

    /// <summary>
    /// გადასახდელი თანხა
    /// </summary>
    public double Amount { get; set; }

    public virtual OperationMonths OpMonthDate { get; set; } = null!;

    public virtual ICollection<SalaryChargesChanges> SalaryChargesChanges { get; set; } =
        new List<SalaryChargesChanges>();

    public virtual TeacherContracts? TeacherContract { get; set; }
}
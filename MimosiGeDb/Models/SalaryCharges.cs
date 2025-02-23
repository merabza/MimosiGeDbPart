namespace MimosiGeDb.Models;

public partial class SalaryCharges
{
    public int Id { get; set; }

    public int OpMonthDateId { get; set; }

    public int? TeacherContractId { get; set; }

    public double Amount { get; set; }
}
namespace MimosiGeDb.Models;

public partial class TeacherSalarySchemes
{
    public int Id { get; set; }

    public string? SchemaName { get; set; }

    public double? HourSalaryNet { get; set; }

    public double? HourSalaryGross { get; set; }
}
namespace MimosiGeDb.Models;

public sealed class Stuff
{
    public int Id { get; set; }

    /// <summary>
    ///     პიროვნება
    /// </summary>
    public int HumanId { get; set; }

    /// <summary>
    ///     ანგარიშის ნომერი
    /// </summary>
    public string BankAccount { get; set; } = null!;

    /// <summary>
    ///     ბანკის კოდი
    /// </summary>
    public string? BankAccountCode { get; set; }

    /// <summary>
    ///     მონაწილეობს სახელფასო პროგრამაში
    /// </summary>
    public bool SalaryProgram { get; set; }
}
namespace MimosiGeDb.Models;

public class SalaryLineDetail
{
    /// <summary>
    ///     სტრიქონის იდენტიფიკატორი
    /// </summary>
    public int SadId { get; set; }

    /// <summary>
    ///     სათაურის იდენტიფიკატორი
    /// </summary>
    public int SaId { get; set; }

    /// <summary>
    ///     გადასარიცხი თანხა
    /// </summary>
    public decimal SadAmount { get; set; }

    /// <summary>
    ///     ჯგუფი
    /// </summary>
    public int GroupId { get; set; }

    /// <summary>
    ///     საათების რაოდენობა
    /// </summary>
    public float SadHoursCount { get; set; }

    /// <summary>
    ///     ერთი საათის ღირებულება
    /// </summary>
    public decimal SadHourCost { get; set; }

    public virtual Group Group { get; set; } = null!;

    public virtual SalaryLines Sa { get; set; } = null!;
}
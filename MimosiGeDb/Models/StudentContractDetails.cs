namespace MimosiGeDb.Models;

public partial class StudentContractDetails
{
    public int Id { get; set; }

    public int? StudentContractId { get; set; }

    public int CourceId { get; set; }

    public int GroupSizeId { get; set; }

    public float FourWeekHours { get; set; }

    public decimal FourWeekFee { get; set; }

    public decimal OneHourFee { get; set; }
}
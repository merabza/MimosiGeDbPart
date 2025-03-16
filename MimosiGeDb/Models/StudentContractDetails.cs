namespace MimosiGeDb.Models;

public partial class StudentContractDetails
{
    public int Id { get; set; }

    public int? StudentContractId { get; set; }

    /// <summary>
    /// საგანი
    /// </summary>
    public int CourseId { get; set; }

    /// <summary>
    /// ჯგუფის ზომა (ტიპი)
    /// </summary>
    public int GroupSizeId { get; set; }

    /// <summary>
    /// 4 კვირაში საათების რაოდენობა
    /// </summary>
    public float FourWeekHours { get; set; }

    /// <summary>
    /// 4 კვირაში გადასახადი
    /// </summary>
    public decimal FourWeekFee { get; set; }

    /// <summary>
    /// ერთი საათის ღირებულება
    /// </summary>
    public decimal OneHourFee { get; set; }

    public virtual Courses Course { get; set; } = null!;

    public virtual GroupSize GroupSize { get; set; } = null!;

    public virtual StudentContract? StudentContract { get; set; }
}
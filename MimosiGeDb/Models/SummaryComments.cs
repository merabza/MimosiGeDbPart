namespace MimosiGeDb.Models;

public partial class SummaryComments
{
    public int Id { get; set; }

    public int CourceId { get; set; }

    public int TeacherContractId { get; set; }

    public int StudentContractId { get; set; }

    public int OperationMonthDateId { get; set; }

    public string? CommentText { get; set; }
}
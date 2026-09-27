using System;

namespace MimosiGeDbPart.Db.Models;

public sealed class CrmCall
{
    public int CcId { get; set; }

    /// <summary>
    ///     მოსწავლის იდენტიფიკატორი
    /// </summary>
    public int StudentContractId { get; set; }

    /// <summary>
    ///     დარეკვის მიზეზის იდენტიფიკატორი
    /// </summary>
    public int CallTypeId { get; set; } = 1;

    /// <summary>
    ///     დარეკვის თარიღი
    /// </summary>
    public DateTime CallDate { get; set; }

    /// <summary>
    ///     შედეგი
    /// </summary>
    public int AnswerTypeId { get; set; }

    /// <summary>
    ///     საუბრის შინაარსი
    /// </summary>
    public string? CallConversation { get; set; }

    /// <summary>
    ///     უნდა გადაიხადოს თარიღამდე
    /// </summary>
    public DateTime? MustPayDate { get; set; }

    public CrmAnswerType AnswerType { get; set; } = null!;

    public CrmCallType CallType { get; set; } = null!;

    public StudentContract StudentContract { get; set; } = null!;
}

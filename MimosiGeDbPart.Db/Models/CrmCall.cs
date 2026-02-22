using System;

namespace MimosiGeDbPart.Db.Models;

public sealed class CrmCall
{
    private CrmAnswerType? _answerTypeNavigation;

    private CrmCallType? _callTypeNavigation;

    private StudentContract? _studentContractNavigation;
    public int CcId { get; set; }

    /// <summary>
    ///     მოსწავლის იდენტიფიკატორი
    /// </summary>
    public int StudentContractId { get; set; }

    /// <summary>
    ///     დარეკვის მიზეზის იდენტიფიკატორი
    /// </summary>
    public int CallTypeId { get; set; }

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

    public CrmAnswerType AnswerTypeNavigation
    {
        get =>
            _answerTypeNavigation ??
            throw new InvalidOperationException("Uninitialized property: " + nameof(AnswerTypeNavigation));
        set => _answerTypeNavigation = value;
    }

    public CrmCallType CallTypeNavigation
    {
        get =>
            _callTypeNavigation ??
            throw new InvalidOperationException("Uninitialized property: " + nameof(CallTypeNavigation));
        set => _callTypeNavigation = value;
    }

    public StudentContract StudentContractNavigation
    {
        get =>
            _studentContractNavigation ??
            throw new InvalidOperationException("Uninitialized property: " + nameof(StudentContractNavigation));
        set => _studentContractNavigation = value;
    }
}

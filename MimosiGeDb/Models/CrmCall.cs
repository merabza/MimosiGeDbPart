using System;

namespace MimosiGeDb.Models;

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

    private CrmAnswerType? _answerTypeNavigation;
    public CrmAnswerType AnswerTypeNavigation
    {
        get =>
            _answerTypeNavigation ??
            throw new InvalidOperationException("Uninitialized property: " + nameof(AnswerTypeNavigation));
        set => _answerTypeNavigation = value;
    }

    private CrmCallType? _callTypeNavigation;
    public CrmCallType CallTypeNavigation
    {
        get =>
            _callTypeNavigation ??
            throw new InvalidOperationException("Uninitialized property: " + nameof(CallTypeNavigation));
        set => _callTypeNavigation = value;
    }

    private StudentContract? _studentContractNavigation;
    public StudentContract StudentContractNavigation
    {
        get =>
            _studentContractNavigation ??
            throw new InvalidOperationException("Uninitialized property: " + nameof(StudentContractNavigation));
        set => _studentContractNavigation = value;
    }
}
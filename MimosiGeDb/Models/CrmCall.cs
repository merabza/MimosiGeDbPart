using System;

namespace MimosiGeDb.Models;

public partial class CrmCall
{
    public int Id { get; set; }

    public int StudentContractId { get; set; }

    public int? CallType { get; set; }

    public DateTime? CallDate { get; set; }

    public int? AnswerType { get; set; }

    public string? CallConv { get; set; }

    public DateTime? MustPayDate { get; set; }
}
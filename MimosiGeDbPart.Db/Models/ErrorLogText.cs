using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using BackendCarcass.Domain;

namespace MimosiGeDbPart.Db.Models;

public sealed class ErrorLogText : IDataType
{
    public int EltId { get; set; }

    /// <summary>
    ///     შეცდომის ტექსტი
    /// </summary>
    public required string Text { get; set; }

    public ICollection<LessonCheckCreateErrorLog> LessonsCheckCreateErrorLogs { get; set; } =
        new List<LessonCheckCreateErrorLog>();

    [NotMapped]
    public int Id
    {
        get => EltId;
        set => EltId = value;
    }

    [NotMapped] public string? Key => null;

    [NotMapped] public string Name => Text;

    [NotMapped] public int? ParentId => null;

    public bool UpdateTo(IDataType data)
    {
        if (data is not ErrorLogText other)
        {
            return false;
        }

        Text = other.Text;
        return true;
    }

    public dynamic EditFields()
    {
        return new ErrorLogText { EltId = EltId, Text = Text };
    }
}

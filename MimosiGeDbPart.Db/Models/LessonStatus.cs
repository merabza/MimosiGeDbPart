using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using BackendCarcass.Domain;

namespace MimosiGeDbPart.Db.Models;

public sealed class LessonStatus : IDataType
{
    public int Id { get; set; }

    /// <summary>
    ///     სტატუსის დასახელება
    /// </summary>
    public required string StatusName { get; set; }

    public ICollection<Lesson> Lessons { get; set; } = new List<Lesson>();

    [NotMapped] public string? Key => null;

    [NotMapped] public string Name => StatusName;

    [NotMapped] public int? ParentId => null;

    public bool UpdateTo(IDataType data)
    {
        if (data is not LessonStatus other)
        {
            return false;
        }

        StatusName = other.StatusName;
        return true;
    }

    public dynamic EditFields()
    {
        return new LessonStatus { Id = Id, StatusName = StatusName };
    }
}

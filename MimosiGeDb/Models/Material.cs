using System.Collections.Generic;

namespace MimosiGeDb.Models;

public sealed class Material
{
    public int Id { get; set; }

    /// <summary>
    ///     ავტორები
    /// </summary>
    public required string MatAuthors { get; set; }

    /// <summary>
    ///     წიგნის ან სასწავლო მასალის დასახელება
    /// </summary>
    public required string MatName { get; set; }

    /// <summary>
    ///     ტიპი
    /// </summary>
    public int MatTypeId { get; set; }

    /// <summary>
    ///     გამოშვების წელი
    /// </summary>
    public int MatYear { get; set; }

    public MaterialType MatType { get; set; } = null!;

    public ICollection<LessonMaterial> LessonMaterials { get; set; } = new List<LessonMaterial>();
}
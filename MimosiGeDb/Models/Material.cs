﻿using System.Collections.Generic;

namespace MimosiGeDb.Models;

public class Material
{
    public int Id { get; set; }

    /// <summary>
    /// ავტორები
    /// </summary>
    public string MatAuthors { get; set; } = null!;

    /// <summary>
    /// წიგნის ან სასწავლო მასალის დასახელება
    /// </summary>
    public string MatName { get; set; } = null!;

    /// <summary>
    /// ტიპი
    /// </summary>
    public int MatTypeId { get; set; }

    /// <summary>
    /// გამოშვების წელი
    /// </summary>
    public int MatYear { get; set; }

    public virtual MaterialType MatType { get; set; } = null!;

    public virtual ICollection<LessonMaterial> LessonBooksAndMaterials { get; set; } = new List<LessonMaterial>();
}
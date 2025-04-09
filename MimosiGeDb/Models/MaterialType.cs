using System.Collections.Generic;

namespace MimosiGeDb.Models;

public sealed class MaterialType
{
    public int MtId { get; set; }

    /// <summary>
    ///     სასწავლო მასალის ტიპის დასახელება
    /// </summary>
    public string? MtName { get; set; }

    public ICollection<Material> BooksAndMaterials { get; set; } = new List<Material>();
}
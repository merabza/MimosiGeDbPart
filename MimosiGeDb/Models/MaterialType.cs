using System.Collections.Generic;

namespace MimosiGeDb.Models;

public class MaterialType
{
    public int MtId { get; set; }

    /// <summary>
    ///     სასწავლო მასალის ტიპის დასახელება
    /// </summary>
    public string? MtName { get; set; }

    public virtual ICollection<Material> BooksAndMaterials { get; set; } = new List<Material>();
}
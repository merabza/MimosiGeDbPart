namespace MimosiGeDb.Models;

public partial class BookOrMaterial
{
    public int Id { get; set; }

    public string BmAuthors { get; set; } = null!;

    public string BmName { get; set; } = null!;

    public int BmTypeId { get; set; }

    public int BmYear { get; set; }
}
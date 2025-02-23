namespace MimosiGeDb.Models;

public partial class LessonBooksAndMaterials
{
    public int Id { get; set; }

    public int LessonId { get; set; }

    public int BmId { get; set; }
}
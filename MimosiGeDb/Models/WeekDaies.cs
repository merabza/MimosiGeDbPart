namespace MimosiGeDb.Models;

public partial class WeekDaies
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? ShortName { get; set; }

    public float? WeekDeyNom { get; set; }
}
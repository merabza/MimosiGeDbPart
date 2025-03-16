namespace MimosiGeDb.Models;

public class GeoMonth
{
    public int GmnId { get; set; }

    /// <summary>
    ///     თვის სახელი
    /// </summary>
    public required string GmnName { get; set; }

    /// <summary>
    ///     მიცემით ბრუნვაში
    /// </summary>
    public required string GmnDative { get; set; }
}
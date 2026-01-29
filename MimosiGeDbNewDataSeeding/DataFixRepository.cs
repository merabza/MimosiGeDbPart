using Microsoft.Extensions.Logging;
using MimosiGeDb;

namespace MimosiGeDbNewDataSeeding;

public sealed class DataFixRepository : IDataFixRepository
{
    private readonly MimosiGeDbContext _context;
    // ReSharper disable once NotAccessedField.Local
#pragma warning disable S4487
    private readonly ILogger<DataFixRepository> _logger;
#pragma warning restore S4487

    public DataFixRepository(MimosiGeDbContext context, ILogger<DataFixRepository> logger)
    {
        _context = context;
        _logger = logger;
    }

    public void SaveChanges()
    {
        _context.SaveChanges();
    }
}

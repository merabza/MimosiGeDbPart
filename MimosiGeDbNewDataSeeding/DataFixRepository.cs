using Microsoft.Extensions.Logging;
using MimosiGeDb;

namespace MimosiGeDbNewDataSeeding;

public sealed class DataFixRepository : IDataFixRepository
{
    private readonly MimosiGeDbContext _context;
    private readonly ILogger<DataFixRepository> _logger;

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
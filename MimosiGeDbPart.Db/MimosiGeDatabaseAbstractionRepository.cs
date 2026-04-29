using BackendCarcass.Database;

namespace MimosiGeDbPart.Db;

public sealed class MimosiGeDatabaseAbstractionRepository : CarcassDatabaseAbstractionRepository
{
    public MimosiGeDatabaseAbstractionRepository(MimosiGeDbContext dbContext) : base(dbContext)
    {
    }
}

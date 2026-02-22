using BackendCarcass.Database;

namespace MimosiGeDbPart.Db;

public class MimosiGeUnitOfWork : CarcassUnitOfWork
{
    public MimosiGeUnitOfWork(MimosiGeDbContext dbContext) : base(dbContext)
    {
    }
}

using BackendCarcass.Database;

namespace MimosiGeDb;

public class MimosiGeUnitOfWork : CarcassUnitOfWork
{
    public MimosiGeUnitOfWork(MimosiGeDbContext dbContext) : base(dbContext)
    {
    }
}

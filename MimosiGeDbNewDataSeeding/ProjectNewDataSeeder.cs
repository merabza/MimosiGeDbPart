using CarcassDataSeeding;
using Microsoft.Extensions.Logging;
using MimosiGeDbDataSeeding;

namespace MimosiGeDbNewDataSeeding;

public sealed class ProjectNewDataSeeder : ProjectDataSeeder
{
    private readonly IDataFixRepository _dataFixRepository;

    // ReSharper disable once ConvertToPrimaryConstructor
    public ProjectNewDataSeeder(ILogger<CarcassDataSeeder> logger, CarcassDataSeedersFactory dataSeedersFactory,
        IDataFixRepository dataFixRepository, bool checkOnly) : base(logger, dataSeedersFactory, checkOnly)
    {
        _dataFixRepository = dataFixRepository;
    }

    public override bool SeedData()
    {
        if (!base.SeedData())
            return false;

        Logger.LogInformation("Seed Agr Project New Data Seeder Started");

        var afterSeeDataFixer = new DataFixer(Logger, _dataFixRepository);

        Logger.LogInformation("Running DataFixer");
        return afterSeeDataFixer.Run();
    }
}
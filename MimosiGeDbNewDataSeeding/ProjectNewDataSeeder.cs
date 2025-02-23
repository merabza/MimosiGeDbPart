using System.Collections.Generic;
using CarcassDataSeeding;
using MimosiGeDbDataSeeding;
using LanguageExt;
using Microsoft.Extensions.Logging;
using SystemToolsShared.Errors;

namespace MimosiGeDbNewDataSeeding;

public sealed class ProjectNewDataSeeder : ProjectDataSeeder
{
    private readonly IDataFixRepository _dataFixRepository;

    // ReSharper disable once ConvertToPrimaryConstructor
    public ProjectNewDataSeeder(ILogger<CarcassDataSeeder> logger, DataSeedersFabric dataSeedersFabric,
        IDataFixRepository dataFixRepository, bool checkOnly) : base(logger, dataSeedersFabric, checkOnly)
    {
        _dataFixRepository = dataFixRepository;
    }

    protected override Option<IEnumerable<Err>> SeedProjectSpecificData()
    {
        //AgrNewDataSeedersFabric seederFabric = (AgrNewDataSeedersFabric)DataSeedersFabric;

        Logger.LogInformation("Seed Agr Project New Data Seeder Started");

        var result = base.SeedProjectSpecificData();
        if (result.IsSome)
            return (Err[])result;

        var afterSeeDataFixer = new DataFixer(Logger, _dataFixRepository);

        Logger.LogInformation("Running DataFixer");
        if (!afterSeeDataFixer.Run())
            return new Err[]
            {
                new()
                {
                    ErrorCode = "DataFixerDoesNotWorkingProperly",
                    ErrorMessage = "DataFixer does not working properly"
                }
            };
        return null;
    }
}
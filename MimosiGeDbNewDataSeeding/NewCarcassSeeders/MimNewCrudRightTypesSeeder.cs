using DatabaseToolsShared;
using MimosiGeDbDataSeeding;
using MimosiGeDbDataSeeding.CarcassSeeders;

namespace MimosiGeDbNewDataSeeding.NewCarcassSeeders;

public /*open*/ class MimNewCrudRightTypesSeeder : MimCrudRightTypesSeeder
{
    // ReSharper disable once ConvertToPrimaryConstructor
    public MimNewCrudRightTypesSeeder(string dataSeedFolder, IMimDataSeederRepository repo) : base(dataSeedFolder, repo,
        ESeedDataType.OnlyRules)
    {
    }
}
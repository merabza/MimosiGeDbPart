using MimosiGeDbDataSeeding;
using MimosiGeDbDataSeeding.CarcassSeeders;
using SystemTools.DatabaseToolsShared;
using SystemTools.DomainShared.Repositories;

namespace MimosiGeDbNewDataSeeding.NewCarcassSeeders;

public /*open*/ class MimNewCrudRightTypesSeeder : MimCrudRightTypesSeeder
{
    // ReSharper disable once ConvertToPrimaryConstructor
    public MimNewCrudRightTypesSeeder(string dataSeedFolder, IMimDataSeederRepository repo, IUnitOfWork unitOfWork) :
        base(dataSeedFolder, repo, unitOfWork, ESeedDataType.OnlyRules)
    {
    }
}

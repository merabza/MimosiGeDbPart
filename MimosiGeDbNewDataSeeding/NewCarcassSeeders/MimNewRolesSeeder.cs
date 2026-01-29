using BackendCarcass.MasterData.Models;
using Microsoft.AspNetCore.Identity;
using MimosiGeDbDataSeeding;
using MimosiGeDbDataSeeding.CarcassSeeders;
using SystemTools.DatabaseToolsShared;
using SystemTools.DomainShared.Repositories;

namespace MimosiGeDbNewDataSeeding.NewCarcassSeeders;

public /*open*/ class MimNewRolesSeeder : MimRolesSeeder
{
    // ReSharper disable once ConvertToPrimaryConstructor
    public MimNewRolesSeeder(RoleManager<AppRole> roleManager, string secretDataFolder, string dataSeedFolder,
        IMimDataSeederRepository repo, IUnitOfWork unitOfWork) : base(roleManager, secretDataFolder, dataSeedFolder,
        repo, unitOfWork, ESeedDataType.OnlyRules)
    {
    }
}

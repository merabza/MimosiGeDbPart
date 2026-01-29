using BackendCarcass.MasterData.Models;
using CarcassMasterDataDom.Models;
using DatabaseToolsShared;
using Microsoft.AspNetCore.Identity;
using MimosiGeDbDataSeeding;
using MimosiGeDbDataSeeding.CarcassSeeders;
using SystemTools.DatabaseToolsShared;

namespace MimosiGeDbNewDataSeeding.NewCarcassSeeders;

public /*open*/ class MimNewRolesSeeder : MimRolesSeeder
{
    // ReSharper disable once ConvertToPrimaryConstructor
    public MimNewRolesSeeder(RoleManager<AppRole> roleManager, string secretDataFolder, string dataSeedFolder,
        IMimDataSeederRepository repo) : base(roleManager, secretDataFolder, dataSeedFolder, repo,
        ESeedDataType.OnlyRules)
    {
    }
}

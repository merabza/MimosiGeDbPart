using BackendCarcass.MasterData.Models;
using CarcassMasterDataDom.Models;
using DatabaseToolsShared;
using Microsoft.AspNetCore.Identity;
using MimosiGeDbDataSeeding;
using MimosiGeDbDataSeeding.CarcassSeeders;
using SystemTools.DatabaseToolsShared;

namespace MimosiGeDbNewDataSeeding.NewCarcassSeeders;

public /*open*/ class MimNewUsersSeeder : MimUsersSeeder
{
    // ReSharper disable once ConvertToPrimaryConstructor
    public MimNewUsersSeeder(UserManager<AppUser> userManager, string secretDataFolder, string dataSeedFolder,
        IMimDataSeederRepository repo) : base(userManager, secretDataFolder, dataSeedFolder, repo,
        ESeedDataType.OnlyRules)
    {
    }
}

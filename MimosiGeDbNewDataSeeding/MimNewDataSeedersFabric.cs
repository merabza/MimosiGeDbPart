using CarcassDataSeeding;
using CarcassMasterDataDom.Models;
using DatabaseToolsShared;
using Microsoft.AspNetCore.Identity;
using MimosiGeDbDataSeeding;
using MimosiGeDbNewDataSeeding.NewSeeders;

namespace MimosiGeDbNewDataSeeding;

public sealed class MimNewDataSeedersFabric : MimDataSeedersFabric
{
    // ReSharper disable once ConvertToPrimaryConstructor
    public MimNewDataSeedersFabric(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager,
        string secretDataFolder, string dataSeedFolder, ICarcassDataSeederRepository carcassRepo,
        IMimDataSeederRepository repo) : base(userManager, roleManager, secretDataFolder, dataSeedFolder, carcassRepo,
        repo)
    {
    }

    public override ITableDataSeeder CreateCrmAnswerTypeSeeder()
    {
        return new MimNewCrmAnswerTypeSeeder(DataSeedFolder, Repo);
    }
}
using CarcassDataSeeding;
using CarcassMasterDataDom.Models;
using Microsoft.AspNetCore.Identity;
using MimosiGeDbDataSeeding;

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
}
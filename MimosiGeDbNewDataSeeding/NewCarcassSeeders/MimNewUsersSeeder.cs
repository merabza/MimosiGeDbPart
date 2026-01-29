using BackendCarcass.MasterData.Models;
using Microsoft.AspNetCore.Identity;
using MimosiGeDbDataSeeding;
using MimosiGeDbDataSeeding.CarcassSeeders;
using SystemTools.DatabaseToolsShared;
using SystemTools.DomainShared.Repositories;

namespace MimosiGeDbNewDataSeeding.NewCarcassSeeders;

public /*open*/ class MimNewUsersSeeder : MimUsersSeeder
{
    // ReSharper disable once ConvertToPrimaryConstructor
    public MimNewUsersSeeder(UserManager<AppUser> userManager, string secretDataFolder, string dataSeedFolder,
        IMimDataSeederRepository repo, IUnitOfWork unitOfWork) : base(userManager, secretDataFolder, dataSeedFolder,
        repo, unitOfWork, ESeedDataType.OnlyRules)
    {
    }
}

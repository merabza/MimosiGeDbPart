using BackendCarcass.DataSeeding;
using BackendCarcass.MasterData.Models;
using CarcassDataSeeding;
using CarcassMasterDataDom.Models;
using DatabaseToolsShared;
using Microsoft.AspNetCore.Identity;
using MimosiGeDbDataSeeding;
using MimosiGeDbNewDataSeeding.NewCarcassSeeders;
using MimosiGeDbNewDataSeeding.NewSeeders;
using SystemTools.DatabaseToolsShared;

namespace MimosiGeDbNewDataSeeding;

public sealed class MimNewDataSeedersFactory : MimDataSeedersFactory
{
    // ReSharper disable once ConvertToPrimaryConstructor
    public MimNewDataSeedersFactory(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager,
        string secretDataFolder, string dataSeedFolder, ICarcassDataSeederRepository carcassRepo,
        IMimDataSeederRepository repo) : base(userManager, roleManager, secretDataFolder, dataSeedFolder, carcassRepo,
        repo)
    {
    }

    public override ITableDataSeeder CreateCrmAnswerTypeSeeder()
    {
        return new MimNewCrmAnswerTypeSeeder(DataSeedFolder, Repo);
    }

    public override ITableDataSeeder CreateWeekDaysSeeder()
    {
        return new MimNewWeekDaysSeeder(DataSeedFolder, Repo);
    }

    public override ITableDataSeeder CreateCrudRightTypesSeeder()
    {
        return new MimNewCrudRightTypesSeeder(DataSeedFolder, Repo);
    }

    public override ITableDataSeeder CreateDataTypesSeeder()
    {
        return new MimNewDataTypesSeeder(DataSeedFolder, CarcassRepo, Repo);
    }

    public override ITableDataSeeder CreateMenuGroupsSeeder()
    {
        return new MimNewMenuGroupsSeeder(DataSeedFolder, Repo);
    }

    public override ITableDataSeeder CreateMenuSeeder()
    {
        return new MimNewMenuSeeder(DataSeedFolder, Repo);
    }

    public override ITableDataSeeder CreateManyToManyJoinsSeeder()
    {
        return new MimNewManyToManyJoinSeeder(SecretDataFolder, DataSeedFolder, CarcassRepo, Repo);
    }

    public override ITableDataSeeder CreateRolesSeeder()
    {
        return new MimNewRolesSeeder(MyRoleManager, SecretDataFolder, DataSeedFolder, Repo);
    }

    public override ITableDataSeeder CreateUsersSeeder()
    {
        return new MimNewUsersSeeder(MyUserManager, SecretDataFolder, DataSeedFolder, Repo);
    }
}

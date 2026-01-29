using BackendCarcass.DataSeeding;
using BackendCarcass.MasterData.Models;
using Microsoft.AspNetCore.Identity;
using MimosiGeDbDataSeeding;
using MimosiGeDbNewDataSeeding.NewCarcassSeeders;
using MimosiGeDbNewDataSeeding.NewSeeders;
using SystemTools.DatabaseToolsShared;
using SystemTools.DomainShared.Repositories;

namespace MimosiGeDbNewDataSeeding;

public sealed class MimNewDataSeedersFactory : MimDataSeedersFactory
{
    // ReSharper disable once ConvertToPrimaryConstructor
    public MimNewDataSeedersFactory(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager,
        string secretDataFolder, string dataSeedFolder, ICarcassDataSeederRepository carcassRepo,
        IMimDataSeederRepository repo, IUnitOfWork unitOfWork) : base(userManager, roleManager, secretDataFolder,
        dataSeedFolder, carcassRepo, repo, unitOfWork)
    {
    }

    public override ITableDataSeeder CreateCrmAnswerTypeSeeder()
    {
        return new MimNewCrmAnswerTypeSeeder(DataSeedFolder, Repo, UnitOfWork);
    }

    public override ITableDataSeeder CreateWeekDaysSeeder()
    {
        return new MimNewWeekDaysSeeder(DataSeedFolder, Repo, UnitOfWork);
    }

    public override ITableDataSeeder CreateCrudRightTypesSeeder()
    {
        return new MimNewCrudRightTypesSeeder(DataSeedFolder, Repo, UnitOfWork);
    }

    public override ITableDataSeeder CreateDataTypesSeeder()
    {
        return new MimNewDataTypesSeeder(DataSeedFolder, CarcassRepo, Repo, UnitOfWork);
    }

    public override ITableDataSeeder CreateMenuGroupsSeeder()
    {
        return new MimNewMenuGroupsSeeder(DataSeedFolder, Repo, UnitOfWork);
    }

    public override ITableDataSeeder CreateMenuSeeder()
    {
        return new MimNewMenuSeeder(DataSeedFolder, Repo, UnitOfWork);
    }

    public override ITableDataSeeder CreateManyToManyJoinsSeeder()
    {
        return new MimNewManyToManyJoinSeeder(SecretDataFolder, DataSeedFolder, CarcassRepo, Repo, UnitOfWork);
    }

    public override ITableDataSeeder CreateRolesSeeder()
    {
        return new MimNewRolesSeeder(MyRoleManager, SecretDataFolder, DataSeedFolder, Repo, UnitOfWork);
    }

    public override ITableDataSeeder CreateUsersSeeder()
    {
        return new MimNewUsersSeeder(MyUserManager, SecretDataFolder, DataSeedFolder, Repo, UnitOfWork);
    }
}

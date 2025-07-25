﻿using CarcassDataSeeding;
using CarcassMasterDataDom.Models;
using DatabaseToolsShared;
using Microsoft.AspNetCore.Identity;
using MimosiGeDbDataSeeding;
using MimosiGeDbNewDataSeeding.NewSeeders;

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

    //public ITableDataSeeder CreateLessonStartTimesSeeder()
    //{
    //    return new MimLessonStartTimesSeeder(DataSeedFolder, Repo);
    //}
}
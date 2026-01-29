using System.Collections.Generic;
using BackendCarcass.Database.Models;
using MimosiGeDbDataSeeding;
using MimosiGeDbDataSeeding.CarcassSeeders;
using SystemTools.DatabaseToolsShared;
using SystemTools.DomainShared.Repositories;

namespace MimosiGeDbNewDataSeeding.NewCarcassSeeders;

public sealed class MimNewMenuGroupsSeeder : MimMenuGroupsSeeder
{
    // ReSharper disable once ConvertToPrimaryConstructor
    public MimNewMenuGroupsSeeder(string dataSeedFolder, IMimDataSeederRepository repo, IUnitOfWork unitOfWork) : base(
        dataSeedFolder, repo, unitOfWork, ESeedDataType.OnlyRules)
    {
    }

    public override List<MenuGroup> CreateListByRules()
    {
        var meng = base.CreateListByRules();
        MenuGroup[] menuGroups =
        [
            //GeoModel
            new()
            {
                MengKey = "HumansAndContracts", MengName = "ადამიანები და კონტრაქტები", SortId = 1, Hidden = false
            },
            new() { MengKey = "GroupsAndLessons", MengName = "ჯგუფები და გაკვეთილები", SortId = 2, Hidden = false },
            new() { MengKey = "CRM", MengName = "მომხმარებელთან ურთიერთობის მართვა", SortId = 3, Hidden = false },
            new() { MengKey = "Accounting", MengName = "ბუღალტერია", SortId = 4, Hidden = false },
            new() { MengKey = "Reports", MengName = "რეპორტები", SortId = 5, Hidden = true }
        ];
        meng.AddRange(menuGroups);
        return meng;
    }
}

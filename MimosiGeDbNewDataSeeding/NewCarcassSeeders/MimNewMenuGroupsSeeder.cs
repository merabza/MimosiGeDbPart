using System.Collections.Generic;
using BackendCarcass.Database.Models;
using CarcassDb.Models;
using DatabaseToolsShared;
using MimosiGeDbDataSeeding;
using MimosiGeDbDataSeeding.CarcassSeeders;
using SystemTools.DatabaseToolsShared;

namespace MimosiGeDbNewDataSeeding.NewCarcassSeeders;

public sealed class MimNewMenuGroupsSeeder : MimMenuGroupsSeeder
{
    // ReSharper disable once ConvertToPrimaryConstructor
    public MimNewMenuGroupsSeeder(string dataSeedFolder, IMimDataSeederRepository repo) : base(dataSeedFolder, repo,
        ESeedDataType.OnlyRules)
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

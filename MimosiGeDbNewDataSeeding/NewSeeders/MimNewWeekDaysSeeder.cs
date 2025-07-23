using System.Collections.Generic;
using System.Linq;
using DatabaseToolsShared;
using MimosiGeDb.Models;
using MimosiGeDbDataSeeding;
using MimosiGeDbDataSeeding.MimosiGeSeeders;

namespace MimosiGeDbNewDataSeeding.NewSeeders;

public sealed class MimNewWeekDaysSeeder : WeekDaysSeeder
{
    // ReSharper disable once ConvertToPrimaryConstructor
    public MimNewWeekDaysSeeder(string dataSeedFolder, IMimDataSeederRepository repo) : base(dataSeedFolder, repo,
        ESeedDataType.OnlyRules, [nameof(WeekDay.ShortName)])
    {
    }

    public override List<WeekDay> CreateListByRules()
    {
        WeekDay[] recordStatuses =
        [
            new() { ShortName = "1-ორ", Name = "ორშაბათი" },
            new() { ShortName = "2-სამ", Name = "სამშაბათი" },
            new() { ShortName = "3-ოთხ", Name = "ოთხშაბათი" },
            new() { ShortName = "4-ხუთ", Name = "ხუთშაბათი" },
            new() { ShortName = "5-პარ", Name = "პარასკევი" },
            new() { ShortName = "6-შაბ", Name = "შაბათი" },
            new() { ShortName = "7-კვ", Name = "კვირა" }
        ];
        return recordStatuses.ToList();
    }
}
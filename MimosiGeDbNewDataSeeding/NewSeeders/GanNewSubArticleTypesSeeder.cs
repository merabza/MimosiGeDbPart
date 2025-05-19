using System.Collections.Generic;
using System.Linq;
using DatabaseToolsShared;
using MimosiGeDb.Models;
using MimosiGeDbDataSeeding;
using MimosiGeDbDataSeeding.MimosiGeSeeders;

namespace MimosiGeDbNewDataSeeding.NewSeeders;

public sealed class MimCrmAnswerTypeSeeder : CrmAnswerTypeSeeder
{
    // ReSharper disable once ConvertToPrimaryConstructor
    public MimCrmAnswerTypeSeeder(string dataSeedFolder, IMimDataSeederRepository repo) : base(dataSeedFolder, repo,
        ESeedDataType.RulesHasMorePriority, [nameof(CrmAnswerType.CatKey)])
    //რადგან SatKey ძველ ბაზაში არ არის, ამიტომ დროებით გასაღებად ვიღებთ SatName ველს.
    //თუმცა როცა რეალურზე მოხვდება SatKey ველი, მერე ის უნდა გახდეს გასაღები
    {
    }

    protected override List<CrmAnswerType> CreateListByRules()
    {
        CrmAnswerType[] recordStatuses =
        [
            new() { CatKey = "ThePhoneIsTurnedOff", AnswerTypeName = "ტელეფონი გათიშული აქვს" },
            new() { CatKey = "DidNotAnswered", AnswerTypeName = "არ გვიპასუხა" },
            new() { CatKey = "Answered", AnswerTypeName = "გვიპასუხა" },
        ];
        return recordStatuses.ToList();
    }
}
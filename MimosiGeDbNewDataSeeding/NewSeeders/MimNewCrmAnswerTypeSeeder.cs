using System.Collections.Generic;
using System.Linq;
using MimosiGeDb.Models;
using MimosiGeDbDataSeeding;
using MimosiGeDbDataSeeding.MimosiGeSeeders;
using SystemTools.DatabaseToolsShared;
using SystemTools.DomainShared.Repositories;

namespace MimosiGeDbNewDataSeeding.NewSeeders;

public sealed class MimNewCrmAnswerTypeSeeder : CrmAnswerTypeSeeder
{
    // ReSharper disable once ConvertToPrimaryConstructor
    public MimNewCrmAnswerTypeSeeder(string dataSeedFolder, IMimDataSeederRepository repo, IUnitOfWork unitOfWork) :
        base(dataSeedFolder, repo, unitOfWork, ESeedDataType.OnlyRules, [nameof(CrmAnswerType.CatKey)])
    //რადგან SatKey ძველ ბაზაში არ არის, ამიტომ დროებით გასაღებად ვიღებთ SatName ველს.
    //თუმცა როცა რეალურზე მოხვდება SatKey ველი, მერე ის უნდა გახდეს გასაღები
    {
    }

    public override List<CrmAnswerType> CreateListByRules()
    {
        CrmAnswerType[] recordStatuses =
        [
            new() { CatKey = "ThePhoneIsTurnedOff", AnswerTypeName = "ტელეფონი გათიშული აქვს" },
            new() { CatKey = "DidNotAnswered", AnswerTypeName = "არ გვიპასუხა" },
            new() { CatKey = "Answered", AnswerTypeName = "გვიპასუხა" }
        ];
        return recordStatuses.ToList();
    }
}

using System.Collections.Generic;
using System.Linq;
using CarcassDataSeeding;
using CarcassDb.Models;
using DatabaseToolsShared;
using MimosiGeDbDataSeeding;
using MimosiGeDbDataSeeding.CarcassSeeders;

namespace MimosiGeDbNewDataSeeding.NewCarcassSeeders;

public sealed class MimNewManyToManyJoinSeeder : MimManyToManyJoinsSeeder
{
    // ReSharper disable once ConvertToPrimaryConstructor
    public MimNewManyToManyJoinSeeder(string secretDataFolder, string dataSeedFolder,
        ICarcassDataSeederRepository carcassRepo, IMimDataSeederRepository repo) : base(secretDataFolder, carcassRepo,
        dataSeedFolder, repo, ESeedDataType.OnlyRules, [
            nameof(ManyToManyJoin.PtId), nameof(ManyToManyJoin.PKey), nameof(ManyToManyJoin.CtId),
            nameof(ManyToManyJoin.CKey)
        ])
    {
    }

    public override List<ManyToManyJoin> CreateListByRules()
    {
        var manyToManyJoinsList = base.CreateListByRules();

        //აქ უნდა მოხდეს იმ ჩანაწერების დაგენერირება დამატებით, რომლებიც პროექტის მხარეს კეთდება და არა კარკასის მხარეს.
        //ამ დამატებითი ჩანაწერების გაკეთების საჭიროება შეიძლება დადგეს,
        //თუ პროგრამაში ცვლილებების გვექნება და პროდაქშენის ბაზაში ეს ჩანაწერები არ გვექნება

        var tempData = DataSeederTempData.Instance;

        var roleTableName = DataSeederRepo.GetTableName<Role>();
        var appClaimTableName = DataSeederRepo.GetTableName<AppClaim>();

        //როლის დატატიპის იდენტიფიკატორი
        var roleDataTypeId = tempData.GetIntIdByKey<DataType>(roleTableName);
        //მენიუს ჯგუფის დატატიპის იდენტიფიკატორი
        var menuGroupDataTypeId = tempData.GetIntIdByKey<DataType>(DataSeederRepo.GetTableName<MenuGroup>());
        //მენიუს ელემენტების დატატიპის იდენტიფიკატორი
        var menuDataTypeId = tempData.GetIntIdByKey<DataType>(DataSeederRepo.GetTableName<MenuItm>());
        //თვითონ დატატიპის დატატიპის იდენტიფიკატორი
        var dataTypeDataTypeId = tempData.GetIntIdByKey<DataType>(DataSeederRepo.GetTableName<DataType>());
        //განსაკუთრებული უფლების დატატიპის იდენტიფიკატორი
        var appClaimDataTypeId = tempData.GetIntIdByKey<DataType>(appClaimTableName);

        //ადმინისტრატორის როლის სახელი
        //const string adminRoleKey = "Admin";
        //ლინგვისტის როლის სახელი
        const string lingRoleKey = "Ling";
        //სპეციალისტის როლის სახელი
        const string specRoleKey = "Spec";

        //dt rol dt AppClaim როლის დატატიპზე მიბმული განსაკუთრებული უფლების დატატიპი
        manyToManyJoinsList.Add(new ManyToManyJoin
        {
            PtId = dataTypeDataTypeId, PKey = roleTableName, CtId = dataTypeDataTypeId, CKey = appClaimTableName
        });

        //განსაკუთრებული უფლებების დარიგება

        //admin AppClaim ადმინისტრატორის როლისათვის განსაკუთრებული უფლებების განსაზღვრა
        string[] appClaimKeysAdmin = ["Confirm", "SaveSamples", "SeeAllIssues"];
        manyToManyJoinsList.AddRange(appClaimKeysAdmin.Select(s => new ManyToManyJoin
        {
            PtId = roleDataTypeId, PKey = AdminRoleKey, CtId = appClaimDataTypeId, CKey = s
        }));

        //Ling AppClaim ლინგვისტის როლისათვის განსაკუთრებული უფლებების განსაზღვრა
        string[] appClaimKeysLing = ["Confirm", "SaveSamples", "SeeAllIssues"];
        manyToManyJoinsList.AddRange(appClaimKeysLing.Select(s => new ManyToManyJoin
        {
            PtId = roleDataTypeId, PKey = lingRoleKey, CtId = appClaimDataTypeId, CKey = s
        }));

        //მენიუს ჯგუფებზე უფლებების დარიგება

        //ling meng ლინგვისტის როლისათვის მენიუს ჯგუფებზე უფლებების განსაზღვრა (ემთხვევა ადმინისტრატორის მენიუს ჯგუფებს)
        //ადმინისტრატორისათვის მენიუს ჯგუფებზე უფლებების განსაზღვრა არ ხდება, რადგან ყველა ჯგუფზე ეძლევა უფლება ერთად
        string[] menGroupKeysLing = ["Model", "Roots", "ModelOverview", "VerbPersonMarkers", "Recounts"];
        manyToManyJoinsList.AddRange(menGroupKeysLing.Select(s => new ManyToManyJoin
        {
            PtId = roleDataTypeId, PKey = lingRoleKey, CtId = menuGroupDataTypeId, CKey = s
        }));

        //spec meng სპეციალისტის როლისათვის მენიუს ჯგუფებზე უფლებების განსაზღვრა 
        string[] menGroupKeysSpec = ["Roots", "Recounts"];
        manyToManyJoinsList.AddRange(menGroupKeysSpec.Select(s => new ManyToManyJoin
        {
            PtId = roleDataTypeId, PKey = specRoleKey, CtId = menuGroupDataTypeId, CKey = s
        }));

        //მენიუს ელემენტებზე უფლებების დარიგება

        //ling menu ლინგვისტის როლისათვის მენიუს ელემენტებზე უფლებების განსაზღვრა
        //ადმინისტრატორისათვის მენიუს ელემენტებზე უფლებების განსაზღვრა არ ხდება,
        //რადგან ყველა ელემენტზე ეძლევა უფლება ერთად
        string[] menKeysLing =
        [
            "derivationTreeEditor", "ForConfirmRootsList", "phoneticsTypes", "phoneticsTypeProhibitions",
            "phoneticsOptions", "phoneticsOptionDetails", "phoneticsChanges", "derivationTypes", "morphemeGroups",
            "morphemeRanges", "phoneticsTypesOverview", "derivationFormulasOverview", "morphemesOverview",
            "nounParadigmsOverview", "verbRowParadigmsOverview", "verbPersonMarkersOverview", "issues",
            "actantCombinationsReCounter", "createAfterDominantPersonMarkers", "createVerbPersonMarkerCombinations",
            "createForRecountVerbPersonMarkers", "createVerbPersonMarkerCombinationFormulaDetails", "verbRowFilters",
            "verbRowFilterDetails", "personVariabilityTypes", "personVariabilityDetails", "pronouns",
            "morphemeRangesByInflectionBlocks", "inflectionBlocks", "inflectionTypes",
            "morphemeRangesByDerivationTypes", "morphPhoneticsOccasions", "labels"
        ];
        manyToManyJoinsList.AddRange(menKeysLing.Select(s => new ManyToManyJoin
        {
            PtId = roleDataTypeId, PKey = lingRoleKey, CtId = menuDataTypeId, CKey = s
        }));

        //spec menu სპეციალისტის როლისათვის მენიუს ელემენტებზე უფლებების განსაზღვრა
        string[] menKeysSpec = ["derivationTreeEditor", "issues"];
        manyToManyJoinsList.AddRange(menKeysSpec.Select(s => new ManyToManyJoin
        {
            PtId = roleDataTypeId, PKey = specRoleKey, CtId = menuDataTypeId, CKey = s
        }));

        return manyToManyJoinsList;
    }
}
using System.Collections.Generic;
using System.Linq;
using BackendCarcass.Database.Models;
using BackendCarcass.DataSeeding;
using BackendCarcass.DataSeeding.Comparers;
using MimosiGeDbDataSeeding;
using MimosiGeDbDataSeeding.CarcassSeeders;
using SystemTools.DatabaseToolsShared;
using SystemTools.DomainShared.Repositories;
using SystemTools.RepositoriesShared;

namespace MimosiGeDbNewDataSeeding.NewCarcassSeeders;

public sealed class MimNewManyToManyJoinSeeder : MimManyToManyJoinsSeeder
{
    // ReSharper disable once ConvertToPrimaryConstructor
    public MimNewManyToManyJoinSeeder(string secretDataFolder, string dataSeedFolder,
        ICarcassDataSeederRepository carcassRepo, IMimDataSeederRepository repo, IUnitOfWork unitOfWork) : base(
        secretDataFolder, carcassRepo, dataSeedFolder, repo, unitOfWork, ESeedDataType.OnlyRules, [
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

        var roleTableName = UnitOfWork.GetTableName<Role>();
        //var appClaimTableName = DataSeederRepo.GetTableName<AppClaim>();

        //როლის დატატიპის იდენტიფიკატორი
        var roleDataTypeId = tempData.GetIntIdByKey<DataType>(roleTableName);
        //მენიუს ჯგუფის დატატიპის იდენტიფიკატორი
        var menuGroupDataTypeId = tempData.GetIntIdByKey<DataType>(UnitOfWork.GetTableName<MenuGroup>());
        //მენიუს ელემენტების დატატიპის იდენტიფიკატორი
        var menuDataTypeId = tempData.GetIntIdByKey<DataType>(UnitOfWork.GetTableName<MenuItm>());
        //თვითონ დატატიპის დატატიპის იდენტიფიკატორი
        //var dataTypeDataTypeId = tempData.GetIntIdByKey<DataType>(UnitOfWork.GetTableName<DataType>());
        //განსაკუთრებული უფლების დატატიპის იდენტიფიკატორი
        //var appClaimDataTypeId = tempData.GetIntIdByKey<DataType>(appClaimTableName);

        //ადმინისტრატორის როლის სახელი
        //const string adminRoleKey = "Admin";
        //ლინგვისტის როლის სახელი
        const string managerRoleKey = "Manager";

        //dt rol dt AppClaim როლის დატატიპზე მიბმული განსაკუთრებული უფლების დატატიპი
        //manyToManyJoinsList.Add(new ManyToManyJoin
        //{
        //    PtId = dataTypeDataTypeId, PKey = roleTableName, CtId = dataTypeDataTypeId, CKey = appClaimTableName
        //});

        //განსაკუთრებული უფლებების დარიგება

        //admin AppClaim ადმინისტრატორის როლისათვის განსაკუთრებული უფლებების განსაზღვრა
        //string[] appClaimKeysAdmin = ["Confirm", "SaveSamples", "SeeAllIssues"];
        //manyToManyJoinsList.AddRange(appClaimKeysAdmin.Select(s => new ManyToManyJoin
        //{
        //    PtId = roleDataTypeId, PKey = AdminRoleKey, CtId = appClaimDataTypeId, CKey = s
        //}));

        //Ling AppClaim ლინგვისტის როლისათვის განსაკუთრებული უფლებების განსაზღვრა
        //string[] appClaimKeysLing = ["Confirm", "SaveSamples", "SeeAllIssues"];
        //manyToManyJoinsList.AddRange(appClaimKeysLing.Select(s => new ManyToManyJoin
        //{
        //    PtId = roleDataTypeId, PKey = managerRoleKey, CtId = appClaimDataTypeId, CKey = s
        //}));

        //მენიუს ჯგუფებზე უფლებების დარიგება

        //ling meng ლინგვისტის როლისათვის მენიუს ჯგუფებზე უფლებების განსაზღვრა (ემთხვევა ადმინისტრატორის მენიუს ჯგუფებს)
        //ადმინისტრატორისათვის მენიუს ჯგუფებზე უფლებების განსაზღვრა არ ხდება, რადგან ყველა ჯგუფზე ეძლევა უფლება ერთად
        string[] menGroupKeysLing = ["HumansAndContracts", "GroupsAndLessons", "CRM", "Accounting"];
        manyToManyJoinsList.AddRange(menGroupKeysLing.Select(s => new ManyToManyJoin
        {
            PtId = roleDataTypeId, PKey = managerRoleKey, CtId = menuGroupDataTypeId, CKey = s
        }));

        ////spec meng სპეციალისტის როლისათვის მენიუს ჯგუფებზე უფლებების განსაზღვრა 
        //string[] menGroupKeysSpec = ["Roots", "Recounts"];
        //manyToManyJoinsList.AddRange(menGroupKeysSpec.Select(s => new ManyToManyJoin
        //{
        //    PtId = roleDataTypeId, PKey = specRoleKey, CtId = menuGroupDataTypeId, CKey = s
        //}));

        //მენიუს ელემენტებზე უფლებების დარიგება

        //ling menu ლინგვისტის როლისათვის მენიუს ელემენტებზე უფლებების განსაზღვრა
        //ადმინისტრატორისათვის მენიუს ელემენტებზე უფლებების განსაზღვრა არ ხდება,
        //რადგან ყველა ელემენტზე ეძლევა უფლება ერთად
        string[] menKeysLing =
        [
            "Humans", "StudentContracts", "TeacherContracts", "Groups",
            "Lessons", "CrmCalls", "ChargesAndPayments", "Deposits", "Payments",
            "Salary", "WorkHours"
        ];
        manyToManyJoinsList.AddRange(menKeysLing.Select(s => new ManyToManyJoin
        {
            PtId = roleDataTypeId, PKey = managerRoleKey, CtId = menuDataTypeId, CKey = s
        }));

        ////spec menu სპეციალისტის როლისათვის მენიუს ელემენტებზე უფლებების განსაზღვრა
        //string[] menKeysSpec = ["derivationTreeEditor", "issues"];
        //manyToManyJoinsList.AddRange(menKeysSpec.Select(s => new ManyToManyJoin
        //{
        //    PtId = roleDataTypeId, PKey = specRoleKey, CtId = menuDataTypeId, CKey = s
        //}));

        return manyToManyJoinsList.Distinct(new ManyToManyJoinComparer()).ToList();
    }
}

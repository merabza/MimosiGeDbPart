using System.Collections.Generic;
using CarcassDataSeeding;
using CarcassDb.Factories;
using CarcassDb.Models;
using DatabaseToolsShared;
using MimosiGeDb.Models;
using MimosiGeDbDataSeeding;
using MimosiGeDbDataSeeding.CarcassSeeders;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace MimosiGeDbNewDataSeeding.NewCarcassSeeders;

public sealed class MimNewDataTypesSeeder : MimDataTypesSeeder
{
    // ReSharper disable once ConvertToPrimaryConstructor
    public MimNewDataTypesSeeder(string dataSeedFolder, ICarcassDataSeederRepository carcassRepo,
        IMimDataSeederRepository repo) : base(carcassRepo, dataSeedFolder, repo, ESeedDataType.OnlyRules)
    {
    }

    public override List<DataType> CreateListByRules()
    {
        var mn = base.CreateListByRules();

        var serializerSettings = new JsonSerializerSettings
        {
            ContractResolver = new CamelCasePropertyNamesContractResolver()
        };

        var newDataTypes = new[]
        {
            //AcademicYear
            DataTypeFactory.Create("აკადემიური წლები", "აკადემიური წელი", "აკადემიური წლის",
                DataSeederRepo.GetTableName<AcademicYear>(), nameof(AcademicYear.AyId),
                nameof(AcademicYear.AcademicYearName), null,
                GetDateOnlyCell(nameof(AcademicYear.StartDate), "სასწავლო წლის დასაწყისი"),
                GetDateOnlyCell(nameof(AcademicYear.FinishDate), "სასწავლო წლის დასასრული")),

            //BankAccounts
            DataTypeFactory.Create("ბანკის ანგარიშები", "ბანკის ანგარიში", "ბანკის ანგარიშის",
                DataSeederRepo.GetTableName<BankAccount>(), nameof(BankAccount.BaId), nameof(BankAccount.BankCode),
                nameof(BankAccount.BankName), GetDateOnlyCell(nameof(BankAccount.AccountNumber), "ანგარიშის ნომერი"),
                GetDateOnlyCell(nameof(BankAccount.DesperateDebt), "უიმედო ვალი")),

            //Courses
            DataTypeFactory.Create("საგნები", "საგანი", "საგნის", DataSeederRepo.GetTableName<Course>(),
                nameof(Course.CrsId), nameof(Course.CourseName), null),

            //CrmAnswerType
            DataTypeFactory.Create("მომხმარებლების პასუხების ტიპები", "მომხმარებლების პასუხის ტიპი",
                "მომხმარებლების პასუხის ტიპი", DataSeederRepo.GetTableName<CrmAnswerType>(),
                nameof(CrmAnswerType.CatId), nameof(CrmAnswerType.CatKey), nameof(CrmAnswerType.AnswerTypeName)),

            //CrmCallType
            DataTypeFactory.Create("მომხმარებლებთან ზარების ტიპები", "მომხმარებლებთან ზარის ტიპი",
                "მომხმარებლებთან ზარის ტიპის", DataSeederRepo.GetTableName<CrmCallType>(), nameof(CrmCallType.CctId),
                nameof(CrmCallType.CallTypeName), null),

            //ErrorLogTexts
            DataTypeFactory.Create("შეცდომების ლოგების ტექსტები", "შეცდომის ლოგის ტექსტი", "შეცდომის ლოგის ტექსტის",
                DataSeederRepo.GetTableName<ErrorLogText>(), nameof(ErrorLogText.EltId), nameof(ErrorLogText.Text),
                null),

            //GeoMonths
            DataTypeFactory.Create("თვეები", "თვე", "თვის", DataSeederRepo.GetTableName<GeoMonth>(),
                nameof(GeoMonth.GmnId), nameof(GeoMonth.GmnName), nameof(GeoMonth.GmnDative)),

            //Groups
            DataTypeFactory.Create("ჯგუფები", "ჯგუფი", "ჯგუფის", DataSeederRepo.GetTableName<Group>(),
                nameof(Group.GrpId), nameof(Group.GroupCode), null,
                GetMdComboCell(nameof(Group.CourseId), "საგანი", DataSeederRepo.GetTableName<Course>()),
                GetMdComboCell(nameof(Group.GroupSizeId), "ჯგუფის ზომა", DataSeederRepo.GetTableName<GroupSize>()),
                GetMdComboCell(nameof(Group.StudentStatusId), "მოსწავლის სტატუსი",
                    DataSeederRepo.GetTableName<StudentStatus>()),
                GetDateOnlyCell(nameof(Group.VoidDate), "ჯგუფის გაუქმების თარიღი")),

            //GroupSizes
            DataTypeFactory.Create("ჯგუფების ზომები", "ჯგუფის ზომა", "ჯგუფის ზომის",
                DataSeederRepo.GetTableName<GroupSize>(), nameof(GroupSize.GrsId), nameof(GroupSize.GrsSize),
                nameof(GroupSize.GrsName))
        };

        mn.AddRange(newDataTypes);

        return mn;
    }
}